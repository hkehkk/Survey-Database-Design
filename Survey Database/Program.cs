//Hannah Kops
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ServiceStack.Redis;

namespace Survey_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = ConfigurationManager.AppSettings["RedisHost"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["RedisPort"]);
            string password = ConfigurationManager.AppSettings["RedisPassword"];

            RedisUtil redisUtil = new RedisUtil(host, port, password);

            //Saving entry into Database
            UserInput ui = new UserInput
            {
                Id = 22,
                FirstName = "Jerry",
                LastName = "McDouglas",
                Email = "bmd@gmail.com",
                State = "Montana",
                County = "Lewis and Clark",
                TotalAcres = 2000,
                OwnedAcres = 2000,
                RentedAcres = 0,
                CropType = "Wheat",
                AcresEachCropType = "1000 acres in spring wheat and 1000 acres in winter wheat",
                SeedMonth = "September for winter wheat and April for spring wheat"
            };

            redisUtil.StoreInput(ui);


            //Saving multiple entries into the database
            List<UserInput> userInputs = new List<UserInput>();
            userInputs.Add(new UserInput { Id = 23, FirstName = "George", LastName = "Hannon" });

        }
    }
}
