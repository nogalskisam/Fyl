using Fyl.Library;
using Fyl.Library.Dto;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenant.Site.Models;

namespace Tenant.Site.Controllers
{
    public class PropertyController : Controller
    {
        private ITenantService _tenantService;

        public PropertyController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View("List", new PropertyListSearchModel());
        }

        public ActionResult List_GetProperties([DataSourceRequest]DataSourceRequest datarequest, string postCode, int? beds)
        {
            return Json(Properties().ToDataSourceResult(datarequest));
            //var request = new PropertyListRequestDto()
            //{
            //    PostCode = postCode,
            //    Beds = beds
            //};

            //var response = _tenantService.GetAvailablePropertiesForList(request);

            //var result = new DataSourceResult()
            //{
            //    Data = response != null ? response.Items : null,
            //    Total = response != null ? response.Count : 0
            //};

            //return Json(result);
        }

        public List<PropertyListModel> Properties()
        {
            return new List<PropertyListModel>()
            {
                new PropertyListModel()
                {
                    PropertyId = Guid.NewGuid(),
                    ImagePath = "http://i.imgur.com/FGzdHVM.png",
                    PostCode = "LS6",
                    Beds = 3
                },
                new PropertyListModel()
                {
                    PropertyId = Guid.NewGuid(),
                    ImagePath = "http://i.imgur.com/BM4ijBC.png",
                    PostCode = "LS6",
                    Beds = 2
                },
                new PropertyListModel()
                {
                    PropertyId = Guid.NewGuid(),
                    ImagePath = "http://i.imgur.com/yWYoGXJ.png",
                    PostCode = "LS6",
                    Beds = 6
                }
            };
        }
    }
}