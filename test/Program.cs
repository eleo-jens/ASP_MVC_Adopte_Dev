using DAL.Entities;
using DAL.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace testDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL.Services.DeveloperService devService = new DeveloperService("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = AdopteUnDev; Integrated Security = True");
            IEnumerable<Developer> devs = devService.Get();

            Console.WriteLine("TEST DE GETALL");
            Console.WriteLine();
            foreach (Developer dev in devs)
            {
                Console.WriteLine(dev.idDev);
                Console.WriteLine(dev.DevName);
                Console.WriteLine(dev.DevFirstName);
            }
            Console.WriteLine("______________________________________");
            Console.WriteLine();

            Console.WriteLine("TEST DE GET(id)");
            Console.WriteLine();
            Developer dev1 = devService.Get(2);
            Console.WriteLine(dev1.idDev);
            Console.WriteLine(dev1.DevName);
            Console.WriteLine(dev1.DevMail);
            Console.WriteLine("______________________________________");
            Console.WriteLine();

            Console.WriteLine("TEST DE GET(id)");
            Console.WriteLine();
            Developer newDev = new Developer()
            {
                DevName = "Samuel",
                DevFirstName = "Legrain",
                DevBirthDate = new DateTime(1987,09,27),
                DevPicture = null,
                DevHourCost = 50,
                DevDayCost = 400,
                DevMonthCost = 8000,
                DevMail = "sam@legrain.com",
                DevCategPrincipal = null
            };
            Console.WriteLine(devService.Insert(newDev));
        }
    }
}
