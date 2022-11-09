using FantasyBets.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FantasyBets.Services
{
    public class LoggedUserService
    {
        private readonly UserManager<FantasyUser> _userManager;
        private readonly StateContainer _stateContainer;
        private readonly IDbContextFactory<DataContext> _dbContextFactory;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        public LoggedUserService(UserManager<FantasyUser> userManager, StateContainer stateContainer,
            IDbContextFactory<DataContext> dbContextFactory)
        {
            _userManager = userManager;
            _stateContainer = stateContainer;
            _dbContextFactory = dbContextFactory;
        }

        public async Task<ClaimsPrincipal> SetLoggedUser(Task<AuthenticationState> authenticationState)
        {
            await _semaphore.WaitAsync();

            try
            {
                if (authenticationState is null)
                    throw new InvalidOperationException("Could not load authentication state."); ;

                var user = (await authenticationState).User;
                if (user is null || user.Identity is null)
                    throw new InvalidOperationException("Could not get user identity.");

                if (!user.Identity.IsAuthenticated)
                {
                    return user;
                }

                var id = _userManager.GetUserId(user);

                using var dbContext = await _dbContextFactory.CreateDbContextAsync();
                _stateContainer.CurrentUser = await dbContext.Users
                    .Include(x => x.BetSelections)
                    .ThenInclude(x => x.BetType)
                    .Include(x => x.BetSelections)
                    .ThenInclude(x => x.Game)
                    .ThenInclude(x => x.Round)
                    .ThenInclude(x => x.Season)
                    .FirstAsync(x => x.Id == id);

                return user;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
