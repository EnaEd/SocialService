using AutoMapper;

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
