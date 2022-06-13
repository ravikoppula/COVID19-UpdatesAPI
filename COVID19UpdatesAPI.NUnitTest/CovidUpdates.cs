using COVID19UpdatesAPI.Services;
using NUnit.Framework;

namespace CovidUpdates
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCOVIDUpdatesTest()
        {
            string fpath = "C:\\Users\\qxz1xpw\\source\\repos\\COVID19UpdatesAPI\\COVID19UpdatesAPI\\Models\\Data\\01-01-2021.csv";
           var status = COVIDUpdatesService.ConvertCsvFileToJsonObject(fpath);

            Assert.IsNotNull(status);
        }


        [Test]
        public void ConvertStringDateToDatimeTest()
        {
            string lastUpdatedDate = "2021-03-01 00:00:00";

            var date = COVIDUpdatesService.ConvertStringDateToDatime(lastUpdatedDate);

            Assert.Pass();
        }
        

    }
}