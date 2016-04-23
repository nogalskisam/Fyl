using Fyl.Library;
using Fyl.Session;
using Kendo.Mvc.UI;
using Landlord.Site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Landlord.Site.Controllers
{
    public class PropertyImageController : Controller
    {
        private ISessionDetails _session;
        private ILandlordService _landlordService;

        public PropertyImageController(ISessionDetails session, ILandlordService landlordService)
        {
            _session = session;
            _landlordService = landlordService;
        }
        
        

        public JsonResult GetPropertyImages(Guid propertyId)
        {
            var dtos = _landlordService.GetPropertyImagesForProperty(propertyId);

            var result = new DataSourceResult()
            {
                Data = dtos,
                Total = dtos.Count
            };

            return Json(result);
        }

        public ActionResult Upload(Guid id)
        {
            var model = new ImageUploadModel()
            {
                PropertyId = id
            };

            return View("_ImageUpload", model);
        }

        [HttpPost]
        public ActionResult Upload(ImageUploadModel model)
        {
            if (ModelState.IsValid)
            {
                foreach(var image in model.Images)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var folder = Path.Combine(@"C:\CDN\", model.PropertyId.ToString());

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }


                    if (Path.GetExtension(image.FileName) == ".jpg")
                    {
                        if (image != null && image.ContentLength > 0)
                        {
                            var propertyImageId = _landlordService.AddPropertyImage(model.PropertyId);
                            var path = Path.Combine(folder, propertyImageId.ToString());

                            path = string.Format("{0}.jpg", path);

                            image.SaveAs(path);
                        }
                    }
                }

                return RedirectToAction("View", "Property", new { id = model.PropertyId });
            }
            else
            {
                return View("_ImageUpload", model);
            }
        }

        [HttpGet]
        public ActionResult Manage(Guid id)
        {
            var dto = _landlordService.GetPropertyImage(id);

            var model = new PropertyImageDetailModel(dto);

            return View("Manage", model);
        }

        [HttpPost]
        public ActionResult Manage(PropertyImageDetailModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = model.ToDto();

                var edited = _landlordService.UpdatePropertyImage(dto);

                return RedirectToAction("View", "Property", new { id = dto.PropertyId });
            }
            else
            {
                return View("Manage", model);
            }
            
        }
    }
}