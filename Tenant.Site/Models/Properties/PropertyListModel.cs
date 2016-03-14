using System;

namespace Tenant.Site.Models
{
    public class PropertyListModel
    {
        public Guid PropertyId { get; set; }

        public string PostCode { get; set; }

        public int Beds { get; set; }

        public string ImagePath { get; set; }
    }
}