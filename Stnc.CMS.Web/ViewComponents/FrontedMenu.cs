using AutoMapper;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json.Linq;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DTO.DTOs.AppUserDtos;
using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.Web.ViewComponents
{
    public class FrontedMenu : ViewComponent
    {

        private readonly IOptionsService _optionsService;

        public FrontedMenu(IOptionsService optionsService)
        {

            _optionsService = optionsService;

        }

        static string htmlReturn(string target, string href, string text, bool li_type = false)
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

  

        public IViewComponentResult Invoke()
        {

            string  json = "{\"menuList\":" + _optionsService.GetOptionName("front-menu")+ "}";
            string menu = "";

                      try
                      {
                          var jObject = JObject.Parse(json);

                          if (jObject != null)
                          {
                              JArray dataArray = (JArray)jObject["menuList"];

                              if (dataArray != null)
                              {
                                  foreach (var item in dataArray)
                                  {

                                      if (item["children"] != null)
                                      {
                                          menu += "<li class=\"has-children\">\n";
                                          menu += htmlReturn(item["target"].ToString(), item["href"].ToString(), item["text"].ToString(), true);

                                          menu += "<ul class=\"dropdown\">\n";
                                          foreach (var itemChild in item["children"])
                                          {
                                              menu += htmlReturn(itemChild["target"].ToString(), itemChild["href"].ToString(), itemChild["text"].ToString());
                                          }
                                          menu += "</ul>\n";
                                          menu += "</li>\n";
                                      }
                                      else
                                      {
                                          menu += "<li>\n";
                                          menu += htmlReturn(item["target"].ToString(), item["href"].ToString(), item["text"].ToString(), true);
                                          menu += "</li>\n";
                                      }
                                  }

                              }
                          }
                      }
                      catch (Exception)
                      {
                          throw;
                      }
            

            return new HtmlContentViewComponentResult(new HtmlString(menu));



        }
    }
}