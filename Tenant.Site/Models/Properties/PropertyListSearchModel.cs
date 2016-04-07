using Fyl.Library.Dto;

namespace Tenant.Site.Models
{
    public class PropertyListSearchModel
    {
        public string Area { get; set; }

        public string PostCode { get; set; }

        public UserDto User { get; set; }
    }
}