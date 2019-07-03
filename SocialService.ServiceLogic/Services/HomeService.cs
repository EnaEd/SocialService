using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialService.ServiceLogic.Services
{
    public class HomeService : IHomeService
    {
        private const int DEFAULT_PAGE = 1;
        private const int DEFAULT_PAGE_SIZE = 5;
        public IndexPageView GetIndexViewModel(int page, List<User> users)
        {
            int count = users.Count();
            List<User> items =  users.Skip((page - DEFAULT_PAGE) * DEFAULT_PAGE_SIZE).Take(DEFAULT_PAGE_SIZE).ToList();

            PageView pageViewModel = new PageView(count, page, DEFAULT_PAGE_SIZE);
            IndexPageView viewModel = new IndexPageView
            {
                PageView = pageViewModel,
                Users = items
            };
            return viewModel;
        }
    }
}
