using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class PropertyRating
    {
        public Guid PropertyRatingId { get; set; }

        public Guid PropertyId { get; set; }

        public Guid UserId { get; set; }

        public int Rating { get; set; }

    }
}
