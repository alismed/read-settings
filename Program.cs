using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Example
{
    class Program
    {
        public static IConfigurationRoot configuration { get; set; }

        static void Main(string[] args)
        {
            Setup();
            Print();
        }

        private static void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
        }

        static void Print(){
            Console.WriteLine(configuration["AppSettings:instance"]);
            Console.WriteLine(configuration["AppSettings:version"]);

            IConfigurationSection myArraySection = configuration.GetSection("Email:ToEmails");
            var itemArray = myArraySection.AsEnumerable();

            foreach(var email in itemArray)
            {
                if(email.Value != null){
                    Console.WriteLine(email.Value);
                }
            }
        }
    }
}
