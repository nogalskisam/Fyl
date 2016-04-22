using Fyl.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Enum
{
    public enum PropertyRequestStatusEnum
    {
        [Display(Name = "Pending", ResourceType = typeof(Strings))]
        Pending = 0,

        [Display(Name = "Accepted", ResourceType = typeof(Strings))]
        Accepted = 1,

        [Display(Name = "Declined", ResourceType = typeof(Strings))]
        Declined = 2
    }
}
