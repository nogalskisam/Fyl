﻿using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Landlord.Site.Models
{
    public class PropertyAddEditModel
    {
        public PropertyAddEditModel()
        {
        }

        public PropertyAddEditModel(PropertyBasicDetailsDto dto)
        {
            Property = new PropertyModel(dto);
            Address = new AddressModel(dto);            
        }

        public PropertyAddEditModel(PropertyDetailedDto dto)
        {
            Property = new PropertyModel(dto);
            Address = new AddressModel(dto);
        }

        public PropertyModel Property { get; set; }

        public AddressModel Address { get; set; }

        public PropertyAddEditDto ToDto()
        {
            return new PropertyAddEditDto()
            {
                Address = new AddressAddDto()
                {
                    AddressId = Address.AddressId,
                    HouseName = Address.HouseName,
                    Address1 = Address.Address1,
                    Address2 = Address.Address2,
                    Area = Address.Area,
                    City = Address.City,
                    County = Address.County,
                    Country = Address.Country,
                    PostCode = Address.PostCode,
                },
                Property = new PropertyAddBasicDto()
                {
                    PropertyId = Property.PropertyId,
                    AddressId = Address.AddressId,
                    Beds = Property.Beds,
                    Deposit = Property.Deposit,
                    Rent = Property.Rent,
                    StartTime = Property.StartDate,
                }
            };
        }
    }
}