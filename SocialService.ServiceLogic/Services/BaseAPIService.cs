using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.ServiceLogic.Services
{
    public class BaseAPIService
    {
        protected readonly IMapper _mapper;
        public BaseAPIService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
