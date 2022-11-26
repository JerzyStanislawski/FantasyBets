using System.Net.Mail;

namespace FantasyBets.Extensions
{
    public static class StringExtensions
    {
        public static string ToUserName(this string email)
        {
            try
            {
                var address = new MailAddress(email);

                return address.User;
            }
            catch
            {
                return "<unknown>";
            }
        }
    }
}
