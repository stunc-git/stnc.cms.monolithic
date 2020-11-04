using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ConsoleApp2
{


    internal class Program
    {

        static string DisplayArray(string target, string href, string text, bool li_type=false)
        {
            if (li_type == false)
            {
                if (target.ToString() != "_self")
                {
                    return "<li><a target=\"" + target + "\" href=\"" + href + "\" class=\"nav-link text-left\">" + text + "</a></li>\n";
                }
                else
                {
                    return "<li><a  href=\"" + href + "\" class=\"nav-link text-left\">" + text + "</a></li>\n";
                }
            }
            else
            {
                return "<a  href=\"" + href + "\" class=\"nav-link text-left\">" + text + "</a>\n";
            }
          
        }

        private static void Main(string[] args)
        {
            string menu = "";
            string jsonFile = @"C:\menu.json";
            var json = File.ReadAllText(jsonFile);

            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray experiencesArrary = (JArray)jObject["menuList"];

                    if (experiencesArrary != null)
                    {
                        foreach (var item in experiencesArrary)
                        {

                            if (item["children"] != null)
                            {
                                menu += "<li class=\"has-children\">\n";
                                menu += DisplayArray(item["target"].ToString(), item["href"].ToString(), item["text"].ToString());
                                
                                menu += "<ul class=\"dropdown\">\n";
                                foreach (var itemChild in item["children"])
                                {
                                    menu += DisplayArray(itemChild["target"].ToString(), itemChild["href"].ToString(), itemChild["text"].ToString());
                                }
                                menu += "</ul>\n";
                                menu += "</li>";
                            } else
                            {
                                menu += "<li>\n";
                                menu += DisplayArray(item["target"].ToString(), item["href"].ToString(), item["text"].ToString(),true);
                                menu += "</li>";
                            }
                        }
                       
                        Console.WriteLine(menu);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}