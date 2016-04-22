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
        
        public ActionResult Index(Guid id)
        {
            var dto = _landlordService.GetPropertyDetails(id);

            var model = new PropertyImageModel()
            {
                PropertyId = dto.PropertyId,
                Address1 = dto.Address1,
                Area = dto.Area,
                City = dto.City,
                PostCode = dto.PostCode,
                Rent = dto.Rent,
                StartDate = dto.StartDate,
                Beds = dto.Beds,
                Deposit = dto.Deposit
            };

            return View("PropertyImage", model);
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

        public ActionResult UploadImages(Guid id)
        {
            var model = new ImageUploadModel()
            {
                PropertyId = id
            };

            return View("_ImageUpload", model);
        }

        [HttpPost]
        public ActionResult UploadImages(ImageUploadModel model)
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

                return RedirectToAction("Index", new { id = model.PropertyId });
            }
            else
            {
                return View("_ImageUpload", model);
            }
        }

    }
}