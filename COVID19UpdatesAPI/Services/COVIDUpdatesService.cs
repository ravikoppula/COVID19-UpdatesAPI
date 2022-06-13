using COVID19UpdatesAPI.Interfaces;
using COVID19UpdatesAPI.Models;
using COVID19UpdatesAPI.Models.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace COVID19UpdatesAPI.Services
{
    public class COVIDUpdatesService : ICOVIDUpdatesService
    {
        #region constructor

        private readonly DataContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public COVIDUpdatesService (DataContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        #endregion

        #region Get COVID19 Cases
        public List<ViewUpdatesVM> GetCOVID19Cases(string country, string state, DateTime lastUpdatedDate)
        {
            // 1. get file path
            string projectRootPath = _hostingEnvironment.ContentRootPath;
            projectRootPath = projectRootPath + "\\Models\\";
            var folderRootPath = Path.GetFullPath(Path.Combine(projectRootPath, "Data\\"));

            // 2.  read files from the local folder/git path 
            var csvFiles = new DirectoryInfo(folderRootPath).GetFiles("*.csv");
            List<string> fileList = new List<string>();
            foreach (var fname in csvFiles)
            {
                string fFullPath = folderRootPath + "\\" + fname.Name;

                fileList.Add(fFullPath);
            }

            // 3. Convert csv to json obj and append to a list
            List<string> jsondata = new List<string>();
            foreach (var fpath in fileList)
            {
                var data = ConvertCsvFileToJsonObject(fpath);
                jsondata.Add(data);

            }
            // 4 append the descObj to list
            List<COVIDUpdatesViewModel> DescObj = new List<COVIDUpdatesViewModel>();
            foreach (string JObj in jsondata)
            {
                var myDeserializedClass = JsonConvert.DeserializeObject<List<COVIDUpdatesViewModel>>(JObj);
                foreach (var plan in myDeserializedClass)
                {
                    var selectedList = new COVIDUpdatesViewModel
                    {
                        FIPS = plan.FIPS,
                        Admin2 = plan.Admin2,
                        Province_State = plan.Province_State,
                        Country_Region = plan.Country_Region,
                        Last_Update = plan.Last_Update,
                        Lat = plan.Lat,
                        Long_ = plan.Long_,
                        Confirmed = plan.Confirmed,
                        Deaths = plan.Deaths,
                        Recovered = plan.Recovered,
                        Active = plan.Active,
                        Combined_Key = plan.Combined_Key,
                        Incident_Rate = plan.Incident_Rate,
                        Case_Fatality_Ratio = plan.Case_Fatality_Ratio,
                        LastUpdatedDate = ConvertStringDateToDatime(plan.Last_Update),
                    };
                    DescObj.Add(selectedList);
                }
            }

            // 5. filter the user inputs
            List<ViewUpdatesVM> covidUpdateList = new List<ViewUpdatesVM>();
            if (lastUpdatedDate == DateTime.MinValue)
            {
                covidUpdateList = DescObj.ToList()
               .Where(a => a.Country_Region == (!String.IsNullOrEmpty(country) ? country : a.Country_Region) && a.Province_State == (!String.IsNullOrEmpty(state) ? state : a.Province_State)
               )
               .Select(x => new ViewUpdatesVM
               {
                   Country_Region = x.Country_Region,
                   Province_State = x.Province_State,
                   Confirmed = x.Confirmed,
                   Deaths = x.Deaths,
                   Recovered = x.Recovered,
                   Active = x.Active,
                   LastUpdatedDate = x.LastUpdatedDate
               }).OrderBy(x => x.LastUpdatedDate).ToList();
            }
            else
            {
                covidUpdateList = DescObj.ToList()
              .Where(a => a.Country_Region == (!String.IsNullOrEmpty(country) ? country : a.Country_Region) && a.Province_State == (!String.IsNullOrEmpty(state) ? state : a.Province_State)
               && a.LastUpdatedDate.Date >= lastUpdatedDate.Date && a.LastUpdatedDate.Date <= lastUpdatedDate.Date
              )
              .Select(x => new ViewUpdatesVM
              {
                  Country_Region = x.Country_Region,
                  Province_State = x.Province_State,
                  Confirmed = x.Confirmed,
                  Deaths = x.Deaths,
                  Recovered = x.Recovered,
                  Active = x.Active,
                  LastUpdatedDate = x.LastUpdatedDate
              }).OrderBy(x => x.LastUpdatedDate).ToList();
            }

            // 6. return the deserialized list
            return covidUpdateList;
        }

        public static string ConvertCsvFileToJsonObject(string path)
        {
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(path);

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult);
        }

        public static DateTime ConvertStringDateToDatime(string _lastUpdatedDate)
        {
            DateTime LastUpdatedDate = new DateTime();
            if (_lastUpdatedDate.Any(char.IsDigit))
                LastUpdatedDate = DateTime.ParseExact(_lastUpdatedDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            return LastUpdatedDate;
        }
       
        #endregion


    }
}
