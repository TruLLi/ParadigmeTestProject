using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vjezba3.ComponentRegistration;
using Vjezba3.Models;

namespace Vjezba3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dependency.Initialize();

            var driver = Dependency.For<IDriversRepository>();
            var newDriver = new Driver
            {
                Id = 1,
                Name = "mario",
                Surname = "zagar",
                Money = 1000
            };

            try
            {
                driver.Create(newDriver);
                driver.Get(newDriver);
                driver.Exists(newDriver);
                driver.Delete(newDriver);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
