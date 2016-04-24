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

        [HttpGet]
        public ActionResult Add()
        {
            var model = new PropertyAddEditModel()
            {
                Property = new PropertyModel(),
                Address = new AddressModel()
            };

            return View("AddProperty", model);
        }

        [HttpPost]
        public ActionResult Add(PropertyAddEditModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = model.ToDto();
                try
                {
                    var userId = _sessionDetails.User.UserId;
                    var id = _landlordService.AddProperty(userId, dto);

                    return RedirectToAction("View", id);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);

                    return View("AddProperty", model);
                }
            }
            else
            {
                return View("AddProperty", model);
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var property = _landlordService.GetPropertyDetails(id);

            var model = new PropertyAddEditModel(property);

            return View("EditProperty", model);
        }

        [HttpPost]
        public ActionResult Edit(PropertyAddEditModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = model.ToDto();

                try
                {
                    var id = _landlordService.EditProperty(_sessionDetails.User.UserId, dto);

                    return RedirectToAction("View", new { id = id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);

                    return View("EditProperty", model);
                }
            }
            else
            {
                return View("EditProperty", model);
            }
        }

        public ActionResult View(Guid id)
        {
            var dto = _landlordService.GetPropertyBasicDetails(id);

            var model = new PropertyDisplayModel()
            {
                PropertyId = dto.PropertyId,
                Address1 = dto.Address1,
                Area = dto.Area,
                City = dto.City,
                PostCode = dto.PostCode,
                Rent = dto.Rent,
                StartDate = dto.StartDate,
                Beds = dto.Beds,
                Deposit = dto.Deposit,
                SignRequestCount = dto.SignRequestCount
            };

            return View("View", model);
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

        public ActionResult ManageSignRequests(Guid id)
        {
            var dtos = _landlordService.GetPropertySignRequestsForPropertyId(id);

            var model = dtos
                .Select(s => new SignRequestModel(s))
                .ToList();

            return View("SignRequests", model);
        }

        public ActionResult RequestRespond(Guid id, Guid propertyId, bool accept)
        {
            var result = _landlordService.SetPropertySignRequest(id, propertyId, accept);

            return RedirectToAction("ManageSignRequests", new { id = propertyId });
        }
    }
}