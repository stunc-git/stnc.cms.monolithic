using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json.Linq;
using Stnc.CMS.Business.Interfaces;
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

        static string HtmlReturn(string target, string href, string text, bool li_type = true)
        {
            if (li_type == true)
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
                                          menu += HtmlReturn(item["target"].ToString(), item["href"].ToString(), item["text"].ToString(), false);

                                          menu += "<ul class=\"dropdown\">\n";
                                          foreach (var itemChild in item["children"])
                                          {
                                              menu += HtmlReturn(itemChild["target"].ToString(), itemChild["href"].ToString(), itemChild["text"].ToString());
                                          }
                                          menu += "</ul>\n";
                                          menu += "</li>\n";
                                      }
                                      else
                                      {
                                          menu += "<li>\n";
                                          menu += HtmlReturn(item["target"].ToString(), item["href"].ToString(), item["text"].ToString(), false);
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



/*
// burası frontende kullanılan menunun yedeği 
< li class= "active" >
  
                              < a href = "/" class= "nav-link text-left" > Anasayfa </ a >
     
                             </ li >
     


                             < li class= "has-children" >
      
                                  < a href = "about.html" class= "nav-link text-left" > Kurumsal </ a >
         
                                     < ul class= "dropdown" >
          
                                          < li >< a href = "/icerik/tarihce" > Tarihçe </ a ></ li >
             
                                             < li >< a href = "/icerik/insan-kaynagi" > İnsan Kaynağı </ a ></ li >
                    
                                                    < li >< a href = "/icerik/arastirma-bolumleri" > Araştırma Bölümleri </ a ></ li >
                           
                                                           < li >< a href = "/icerik/misyon-vizyon" > Misyon & Vizyon </ a ></ li >
                              
                                                              < li >< a href = "/icerik/hayvan-unitesi" > Hayvan Ünitesi </ a ></ li >
                                     
                                                                     < li >< a href = "/icerik/arastirma" > Araştırma </ a ></ li >
                                        
                                                                        < li >< a href = "/icerik/faaliyet-alanlari" > Faaliyet Alanları </ a ></ li >
                                               
                                                                           </ ul >
                                               
                                                                       </ li >
                                               

                                                                       < li class= "has-children" >
                                                
                                                                            < a href = "/icerik/yonetim" class= "nav-link text-left" > Yönetim </ a >
                                                   
                                                                               < ul class= "dropdown" >
                                                    
                                                                                    < li >< a href = "/icerik/yonetim" > Yönetim </ a ></ li >
                                                       
                                                                                       < li >< a href = "/icerik/komisyon-uyeleri" > Komisyon Üyeleri </ a ></ li >
                                                              
                                                                                              < li >< a href = "/icerik/personel" > Personel </ a ></ li >
                                                                 
                                                                                                 < li >< a href = "/icerik/yonetmelikler" > Yönetmelikler </ a ></ li >
                                                                    
                                                                                                </ ul >
                                                                    
                                                                                            </ li >
                                                                    

                                                                                            < li class= "has-children" >
                                                                     
                                                                                                 < a href = "#" class= "nav-link text-left" > Belge & Bilgi </ a >
                                                                        
                                                                                                    < ul class= "dropdown" >
                                                                         
                                                                                                         < li >< a href = "/icerik/calisma-izin-belgesi" > Çalışma İzin Belgesi</a></li>
                                <li><a href = "/icerik/is-akis-semasi" > İş akış Şeması</a></li>
                                <li><a href = "/icerik/istatistikler" > İstatitiskler </ a ></ li >
                                                                                
                                                                                                                < li >< a href= "/icerik/fiyat-listesi" > Fiyat Listesi</a></li>
                                <li><a href = "/icerik/formlar" > Formlar </ a ></ li >
                                                                                
                                                                                                            </ ul >
                                                                                
                                                                                                        </ li >
                                                                                

                                                                                                        < li class= "has-children" >
                                                                                 
                                                                                                             < a href = "/galeri" class= "nav-link text-left" > Galeriler </ a >
                                                                                    
                                                                                                                < ul class= "dropdown" >
                                                                                     
                                                                                                                     < li >< a href = "/galeri" > Resim Galerisi </ a ></ li >
                                                                                            
                                                                                                                            < li >< a href = "teachers.html" > Video Galeri </ a ></ li >
                                                                                                   
                                                                                                                               </ ul >
                                                                                                   
                                                                                                                           </ li >
                                                                                                   

                                                                                                                           < li class= "has-children" >
                                                                                                    
                                                                                                                                < a href = "about.html" class= "nav-link text-left" > İletişim </ a >
                                                                                                       
                                                                                                                                   < ul class= "dropdown" >
                                                                                                        
                                                                                                                                        < li >< a href = "/iletism" > İletişim </ a ></ li > -->
                                @*< li >< a href = "teachers.html" > Sıkça Sorular Sorular</a></li>*@
                            <!--</ul>
                        </li>

                        */
                   