using Fyl.Library;
using Fyl.Library.Dto;
using Fyl.Library.Enum;
using Fyl.Session;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenant.Site.Attributes;
using Tenant.Site.Models;

namespace Tenant.Site.Controllers
{
    public class PropertyController : Controller
    {
        private ITenantService _tenantService;
        private ISessionDetails _sessionDetails;

        public PropertyController(ITenantService tenantService, ISessionDetails sessionDetails)
        {
            _tenantService = tenantService;
            _sessionDetails = sessionDetails;
        }

        [Unsecured]
        public ActionResult Index()
        {
            return View();
        }

        [Unsecured]
        public ActionResult List()
        {
            var model = new PropertyListSearchModel()
            {
                User = _sessionDetails.User
            };
            return View("List", model);
        }

        [Unsecured]
        public ActionResult List_GetProperties([DataSourceRequest]DataSourceRequest datarequest, string postCode, int? beds)
        {
            var request = new PropertyListRequestDto()
            {
                Beds = beds,
                PostCode = postCode
            };
            
            var response = _tenantService.GetAvailablePropertiesForList(request);

            foreach (var item in response.Items)
            {
                if (item.PropertyImageId.HasValue && item.PropertyImageId.Value != Guid.Empty)
                {
                    item.ImagePath = $"{ConfigurationManager.AppSettings["CDNPath"]}{item.PropertyId}/{item.PropertyImageId.Value}.jpg";
                }
                else
                {
                    item.ImagePath = $"{ConfigurationManager.AppSettings["CDNPath"]}/6B1E5AD9-8731-4858-AF3B-07C7B593E905.jpg";
                }
            }

            var result = new DataSourceResult()
            {
                Data = response != null ? response.Items : null,
                Total = response != null ? response.Count : 0
            };

            return Json(result);
        }

        [Unsecured]
        public ActionResult View(Guid id)
        {
            var dto = _tenantService.GetPropertyDetails(id);

            var model = new PropertyModel()
            {
                PropertyId = dto.PropertyId,
                Address1 = dto.Address1,
                Area = dto.Area,
                City = dto.City,
                PostCode = dto.PostCode,
                Beds = dto.Beds,
                Deposit = dto.Deposit,
                Rent = dto.Rent,
                PropertyImageIds = dto.PropertyImageIds,
                StartDate = dto.StartDate
            };

            return View("View", model);
        }

        [HttpGet]
        public ActionResult RequestSign(Guid id)
        {
            var userId = _sessionDetails.User.UserId;
            var requestExists = _tenantService.PropertySignRequestExists(id, userId);

            if (!requestExists)
            {
                var dto = _tenantService.GetPropertyDetails(id);

                var model = new PropertySignRequestModel()
                {
                    PropertyId = dto.PropertyId,
                    Address1 = dto.Address1,
                    Area = dto.Area,
                    City = dto.City,
                    PostCode = dto.PostCode,
                    Beds = dto.Beds,
                    Deposit = dto.Deposit,
                    Rent = dto.Rent,
                    StartDate = dto.StartDate
                };

                return View("Sign/Request", model);
            }
            else
            {
                var status = _tenantService.GetPropertySignRequestForIdAndUser(id, userId);
                return View("Sign/RequestStatus", status);
            }
        }

        [HttpPost]
        public ActionResult RequestSign(PropertySignRequestModel model)
        {
            if (model.AcceptTermsAndConditions)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _tenantService.AddNewPropertySignRequest(model.PropertyId, _sessionDetails.User.UserId);
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", "There was an issue sending your request. Please try again later");

                        return View("Sign/Request", model);
                    }

                    return View("Sign/RequestStatus", PropertyRequestStatusEnum.Pending);
                }
                else
                {
                    ModelState.AddModelError("", "There was an issue sending your request. Please try again later");
                }
            }
            else
            {
                ModelState.AddModelError("", "You must accept the Terms and Conditions to send the request");
            }

            return View("Sign/Request", model);
        }

        public ActionResult MyProperty()
        {
            var dto = _tenantService.GetPropertyForTenantUser(_sessionDetails.User.UserId);

            if (dto != null)
            {
                var model = new PropertyDetailedModel(dto);

                return View("MyProperty", model);
            }
            else
            {
                return View("NoProperty");
            }
        }
    }
}