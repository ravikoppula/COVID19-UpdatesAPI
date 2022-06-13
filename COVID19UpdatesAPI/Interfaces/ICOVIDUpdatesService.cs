using COVID19UpdatesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19UpdatesAPI.Interfaces
{
    public interface ICOVIDUpdatesService
    {
        #region IGet

        List<ViewUpdatesVM> GetCOVID19Cases(string country, string state, DateTime lastUpdatedDate);

        #endregion

    }
}
