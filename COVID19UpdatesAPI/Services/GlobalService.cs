using COVID19UpdatesAPI.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19UpdatesAPI.Services
{
    public class GlobalService
    {
        #region context Injector

        private static DataContext _context;
        public GlobalService(DataContext context)
        {
            _context = context;
        }

        #endregion

        #region DBInstance Configuration
        public static IConfigurationRoot GetJsonConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            return configuration;
        }
        #endregion

    }
}
