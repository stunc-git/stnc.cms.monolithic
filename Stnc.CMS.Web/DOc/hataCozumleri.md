## hatalar 
# dictinary hatası 

InvalidOperationException: The model item passed into the ViewDataDictionary is of type 
'Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos.DeneyHayvaniIrkFiyatCreateDto', but this ViewDataDictionary 
instance requires a model item of type 'Stnc.CMS.Entities.Concrete.DekamProjeDeneyHayvaniIrkFiyat'.

FİX: bu hata geliyorsa view dosyasında tanımlama yanlıştır,
Stnc.CMS.Web\Areas\Admin\Views\_ViewImports.cshtml  buraya gerekli tanımlama ve 
view dosyasından onun çağrılması gerekir. map konusunda ortak olması gereken alnalarada bakınız mesela id gibi,


# No migrations configuration type was found in the assembly hatası 

 faced this problem. My solution:

Exit visual studio

Open your project again on visual studio

Rebuild solution

Then the error removed. And I can run the command.