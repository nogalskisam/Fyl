﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Session
{
    [DataContract]
    public class SessionTicket
    {
        [DataMember]
        public Guid SessionId { get; set; }
    }
}
