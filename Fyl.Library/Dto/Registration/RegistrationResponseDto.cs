using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    public class RegistrationResponseDto
    {
        public bool EmailExists { get; set; }
        
        public bool Success { get; set; }

    }
}
