namespace XParkMinder.AzureMobile.Infrastructure.ServiceLibrary.Configuration
{
    public interface IAzureMobileInfrastructureConfiguration
    {
        string AppUrl { get; }
        string SyncStorePath { get; }
    }
}