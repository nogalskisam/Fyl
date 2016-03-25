using Fyl.Library;
using Fyl.Library.Dto;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            var request = new PropertyListRequestDto()
            {
                Beds = beds,
                PostCode = postCode
            };
            
            var response = _tenantService.GetAvailablePropertiesForList(request);
            var result = new DataSourceResult()
            {
                Data = response != null ? response.Items : null,
                Total = response != null ? response.Count : 0
            };

            return Json(result);
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
                    PropertyId = Guid.Parse("4BA04416-A632-4B90-835F-EC4FC3B5A54F"),
                    //ImagePath = "http://i.imgur.com/FGzdHVM.png",
                    ImagePath = ConfigurationManager.AppSettings["CDNPath"] + "lg.gif",
                    PostCode = "LS6",
                    Beds = 3
                },
                new PropertyListModel()
                {
                    PropertyId = Guid.Parse("A97EDDBB-9C42-4C88-8365-4F3A03832EEC"),
                    //ImagePath = "http://i.imgur.com/BM4ijBC.png",
                    ImagePath = ConfigurationManager.AppSettings["CDNPath"] + "lg2.jpg",
                    PostCode = "LS6",
                    Beds = 2
                },
                new PropertyListModel()
                {
                    PropertyId = Guid.Parse("9D3B0567-8B68-4206-AFB9-1A3980C3B85D"),
                    //ImagePath = "http://i.imgur.com/yWYoGXJ.png",
                    ImagePath = ConfigurationManager.AppSettings["CDNPath"] + "lg.gif",
                    PostCode = "LS6",
                    Beds = 6
                },
                new PropertyListModel()
                {
                    PropertyId = Guid.Parse("A97EDDBB-9C42-4C88-8365-4F3A03832EEC"),
                    //ImagePath = "http://i.imgur.com/BM4ijBC.png",
                    ImagePath = ConfigurationManager.AppSettings["CDNPath"] + "lg2.jpg",
                    PostCode = "LS6",
                    Beds = 2
                },
                new PropertyListModel()
                {
                    PropertyId = Guid.Parse("4BA04416-A632-4B90-835F-EC4FC3B5A54F"),
                    //ImagePath = "http://i.imgur.com/FGzdHVM.png",
                    ImagePath = ConfigurationManager.AppSettings["CDNPath"] + "lg.gif",
                    PostCode = "LS6",
                    Beds = 3
                },
                new PropertyListModel()
                {
                    PropertyId = Guid.Parse("A97EDDBB-9C42-4C88-8365-4F3A03832EEC"),
                    //ImagePath = "http://i.imgur.com/BM4ijBC.png",
                    ImagePath = ConfigurationManager.AppSettings["CDNPath"] + "lg2.jpg",
                    PostCode = "LS6",
                    Beds = 2
                },
                new PropertyListModel()
                {
                    PropertyId = Guid.Parse("4BA04416-A632-4B90-835F-EC4FC3B5A54F"),
                    //ImagePath = "http://i.imgur.com/FGzdHVM.png",
                    ImagePath = ConfigurationManager.AppSettings["CDNPath"] + "lg.gif",
                    PostCode = "LS6",
                    Beds = 3
                },
                new PropertyListModel()
                {
                    PropertyId = Guid.Parse("4BA04416-A632-4B90-835F-EC4FC3B5A54F"),
                    //ImagePath = "http://i.imgur.com/FGzdHVM.png",
                    ImagePath = ConfigurationManager.AppSettings["CDNPath"] + "lg.gif",
                    PostCode = "LS6",
                    Beds = 3
                },
                new PropertyListModel()
                {
                    PropertyId = Guid.Parse("A97EDDBB-9C42-4C88-8365-4F3A03832EEC"),
                    //ImagePath = "http://i.imgur.com/BM4ijBC.png",
                    ImagePath = ConfigurationManager.AppSettings["CDNPath"] + "lg2.jpg",
                    PostCode = "LS6",
                    Beds = 2
                },
            };
        }

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

            //var model = new PropertyModel()
            //{
            //    PropertyId = Guid.Parse("81BB6C15-9C60-4762-8C5F-9556928EC465"),
            //    Beds = 2,
            //    StartDate = DateTime.Now.AddMonths(5),
            //    PropertyImageIds = new List<Guid>()
            //    {
            //        Guid.Parse("556BDEB1-AC10-454A-89FF-565220D81361"),
            //        Guid.Parse("C2549213-C56F-40D6-BFB1-14CB2601434B"),
            //        Guid.Parse("7DFFFCCF-8BE0-40A5-9786-B93FC4CD404D"),
            //        Guid.Parse("786EDCDB-792D-49CB-849D-A9CC4B681237")
            //    },
            //    Address1 = "9 Regency Court",
            //    Area = "Headingley",
            //    City = "Leeds",
            //    PostCode = "LS6 1DW",
            //    RatingAverage = 78
            //};

            return View("View", model);
        }
    }
}