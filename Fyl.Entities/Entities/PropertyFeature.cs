using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class PropertyFeature
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PropertyFeatureId { get; set; }

        public Guid PropertyId { get; set; }

        public PropertyFeatureEnum Feature { get; set; }
    }
}
