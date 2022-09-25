namespace FantasyBets.Services
{
    public class GlobalLock
    {
        private static ManualResetEventSlim _manualResetEvent = new(true);

        public static void Lock()
        {
            _manualResetEvent.Reset();
        }

        public static void Unlock()
        {
            _manualResetEvent.Set();
        }

        public static void Wait(CancellationToken ct = default)
        {
            _manualResetEvent.Wait(ct);
        }
    }
}
