﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class PropertyImage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PropertyImageId { get; set; }

        public Guid PropertyId { get; set; }

        public bool Primary { get; set; }

        public bool Inactive { get; set; }
    }
}
