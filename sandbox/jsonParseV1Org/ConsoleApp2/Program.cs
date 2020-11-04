using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            string menu = "";
                  string jsonFile = @"C:\user.json";
        var json = File.ReadAllText(jsonFile);  

            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    Console.WriteLine("ID :" + jObject["id"].ToString());
                    Console.WriteLine("Name :" + jObject["name"].ToString());

                    var address = jObject["address"];
                    Console.WriteLine("Street :" + address["street"].ToString());
                    Console.WriteLine("City :" + address["city"].ToString());
                    Console.WriteLine("Zipcode :" + address["zipcode"]);
                    JArray experiencesArrary = (JArray)jObject["experiences"];
                    if (experiencesArrary != null)
                    {
                        foreach (var item in experiencesArrary)
                        {
                            Console.WriteLine("company Id :" + item["companyid"]);
                            menu += item["companyid"];
                            Console.WriteLine("company Name :" + item["companyname"].ToString());
                        }

                    }
                    Console.WriteLine("Phone Number :" + jObject["phoneNumber"].ToString());
                    Console.WriteLine("Role :" + jObject["role"].ToString());
                    Console.WriteLine(menu);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
