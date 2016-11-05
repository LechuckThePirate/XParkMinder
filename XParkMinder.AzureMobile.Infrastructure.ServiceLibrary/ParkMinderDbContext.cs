using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using XParkMinder.AzureMobile.Infrastructure.ServiceLibrary.Configuration;
using XParkMinder.Domain.Library.Contracts;
using XParkMinder.Domain.Library.Entities;

namespace XParkMinder.AzureMobile.Infrastructure.ServiceLibrary
{
    public class ParkMinderDbContext
    {
        private MobileServiceClient _client { get; set; } = null;
        private MobileServiceSQLiteStore _store { get; set; } = null;
        private IAzureMobileInfrastructureConfiguration _configuration;


        public ParkMinderDbContext(IAzureMobileInfrastructureConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Initialize()
        {
            if (_client?.SyncContext?.IsInitialized ?? false)
                return;

            var appUrl = _configuration.AppUrl;

            _client = new MobileServiceClient(appUrl);

            var path = _configuration.SyncStorePath;
            path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);

            _store = new MobileServiceSQLiteStore(path);

            //Define table
            _store.DefineTable<Parking>();

            await _client.SyncContext.InitializeAsync(_store, new MobileServiceSyncHandler());
        }

        public IMobileServiceSyncTable<T> GetTable<T>() where T : BaseEntity
        {
            return _client.GetSyncTable<T>();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void RollBackChanges()
        {
            throw new NotImplementedException();
        }
    }
}
