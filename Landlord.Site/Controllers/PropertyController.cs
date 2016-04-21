using Fyl.Library;
using Fyl.Library.Dto;
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
    public class PropertyController : Controller
    {
        private ILandlordService _landlordService;
        private ISessionDetails _sessionDetails;

        public PropertyController(ILandlordService landlordService, ISessionDetails sessionDetails)
        {
            _landlordService = landlordService;
            _sessionDetails = sessionDetails;
        }

        public ActionResult Index()
        {
            return View("Index", new PropertyListModel());
        }

        public JsonResult Index_GetProperties()
        {
            var userId = _sessionDetails.User.UserId;

            var response = _landlordService.GetPropertiesForLandlordList(userId);

            var result = new DataSourceResult()
            {
                Data = response.Items,
                Total = response.Count
            };

            return Json(result);
        }

        public ActionResult PropertyImages(Guid propertyId)
        {
            return View("PropertyImages", new PropertyImageModel());
        }

        public ActionResult AddPropertyImages(PropertyImageAddModel model)
        {
            List<PropertyImageAddDto> dtos = new List<PropertyImageAddDto>();

            if (model.PrimaryImage.ContentLength > 0)
            {
                dtos.Add(new PropertyImageAddDto()
                {
                    PropertyId = model.PropertyId,
                    FileName = Path.GetFileNameWithoutExtension(model.PrimaryImage.FileName),
                    FileExtension = Path.GetExtension(model.PrimaryImage.FileName),
                    Primary = true
                });
            }

            foreach (var image in model.RegularImages)
            {
                dtos.Add(new PropertyImageAddDto()
                {
                    PropertyId = model.PropertyId,
                    FileName = Path.GetFileNameWithoutExtension(model.PrimaryImage.FileName),
                    FileExtension = Path.GetExtension(model.PrimaryImage.FileName),
                    Primary = false
                });
            }

            // do work

            return RedirectToAction("PropertyImages");
        }
    }
}