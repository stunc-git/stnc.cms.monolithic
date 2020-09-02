
## MIGRATIONS

# core  için 

--data access katmanında yapılır yani context in olduğu katmanda 
context file içinde tanımlamalarını yapmayı unutma 

add-migration initalCreate

update-database

burada domain driver deging hakkında bilgielr var 

https://docs.abp.io/en/abp/0.7.0
https://abp.io/#section-2 


# .net 

Enable-Migrations

update-database 


---------------------------

Buraya context ekle  -- stnc.CMS.DataAccess\Concrete\EntityFrameworkCore\Contexts\StncCMSContext.cs
Validation = Stnc.CMS.Web\CustomCollectionExtensions\
DICONTAİNER= Stnc.CMS.Business\DiContainer\CustomExtensions.cs
View İçine Hızlı Veri =Stnc.CMS.Web\Areas\Admin\Views\_ViewImports.cshtml 
map yapmak için =Stnc.CMS.Web\Mapping\AutoMapperProfile\MapProfile.cs


https://medium.com/@gktnkrdg/entity-framework-core-sorgu-etiketleri-query-tags-d912592cdad3
https://gunnarpeipman.com/ef-core-toquerystring/


.net core respository pattern uygulama 
https://medium.com/net-core/repository-pattern-implementation-in-asp-net-core-21e01c6664d7
https://www.programmingwithwolfgang.com/repository-pattern-net-core/

ilişkiler hakkında 
https://docs.microsoft.com/en-us/ef/core/querying/related-data

https://dev.to/_patrickgod/one-to-one-relationship-with-entity-framework-core-3pgg   harika yazı 
