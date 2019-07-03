using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialService.ServiceLogic.Interfaces
{
    public interface IHomeService
    {
        IndexPageView GetIndexViewModel(int page, string userId);
    }
}
