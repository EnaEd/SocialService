using AutoMapper;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.ServiceLogic.Services
{
    public class HomeService : IHomeService
    {
        private const int DEFAULT_PAGE = 1;
        private const int DEFAULT_PAGE_SIZE = 5;
        private FriendService _friendService;
        private IMapper _mapper;
        public HomeService(IConfiguration configuration,IMapper mapper)
        {
            _friendService = new FriendService(configuration, mapper);
            _mapper = mapper;
        }
        public IndexPageView GetIndexViewModel(int page, string userId)
        {
            List<Friend> users= _mapper.Map<List<Friend>>(_friendService.GetAll(userId).ToList());
            int count = users.Count();
            List<Friend> items =  users.Skip((page - DEFAULT_PAGE) * DEFAULT_PAGE_SIZE).Take(DEFAULT_PAGE_SIZE).ToList();

            PageView pageViewModel = new PageView(count, page, DEFAULT_PAGE_SIZE);
            IndexPageView viewModel = new IndexPageView
            {
                PageView = pageViewModel,
                Friends = items
            };
            return viewModel;
        }
    }
}
