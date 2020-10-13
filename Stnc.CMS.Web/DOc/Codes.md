
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

Buraya context ekle  = stnc.CMS.DataAccess\Concrete\EntityFrameworkCore\Contexts\StncCMSContext.cs
Validation = Stnc.CMS.Web\CustomCollectionExtensions\CollectionExtension.cs
DICONTAİNER= Stnc.CMS.Business\DiContainer\CustomExtensions.cs
View İçine Hızlı Veri =Stnc.CMS.Web\Areas\Admin\Views\_ViewImports.cshtml 
Map yapmak için =Stnc.CMS.Web\Mapping\AutoMapperProfile\MapProfile.cs

## hatalar 
# dictinary hatası 

InvalidOperationException: The model item passed into the ViewDataDictionary is of type 
'Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos.DeneyHayvaniIrkFiyatCreateDto', but this ViewDataDictionary 
instance requires a model item of type 'Stnc.CMS.Entities.Concrete.DekamProjeDeneyHayvaniIrkFiyat'.

FİX: bu hata geliyorsa view dosyasında tanımlama yanlıştır,
Stnc.CMS.Web\Areas\Admin\Views\_ViewImports.cshtml  buraya gerekli tanımlama ve 
view dosyasından onun çağrılması gerekir. map konusunda ortak olması gereken alnalarada bakınız mesela id gibi,


