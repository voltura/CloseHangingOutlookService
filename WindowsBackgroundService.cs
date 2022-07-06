namespace CloseHangingOutlookService
{
    public class WindowsBackgroundService : BackgroundService
    {
        private readonly ILogger<WindowsBackgroundService> _logger;
        private readonly CloseOutlookService _closeOutlookService;

        public WindowsBackgroundService(ILogger<WindowsBackgroundService> logger, CloseOutlookService closeOutlookService) => (_logger, _closeOutlookService) = (logger, closeOutlookService);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    if (_closeOutlookService.CloseHangingOutlook()) _logger.LogWarning("Outlook was forcefully closed", DateTimeOffset.Now);
                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);

                // Terminates this process and returns an exit code to the operating system.
                // This is required to avoid the 'BackgroundServiceExceptionBehavior', which
                // performs one of two scenarios:
                // 1. When set to "Ignore": will do nothing at all, errors cause zombie services.
                // 2. When set to "StopHost": will cleanly stop the host, and log errors.
                //
                // In order for the Windows Service Management system to leverage configured
                // recovery options, we need to terminate the process with a non-zero exit code.
                Environment.Exit(1);
            } 
        }
    }
}