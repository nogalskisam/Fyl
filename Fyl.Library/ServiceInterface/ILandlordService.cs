﻿using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library
{
    [ServiceContract]
    public interface ILandlordService
    {
        [OperationContract]
        Task<LoginResponseDto> LoginUser(LoginRequestDto dto);

        [OperationContract]
        SessionDetailDto GetValidSession(Guid sessionId);
    }
}