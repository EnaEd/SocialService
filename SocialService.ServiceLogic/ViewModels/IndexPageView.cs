using SocialService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.ServiceLogic.ViewModels
{
    public class IndexPageView
    {
        public IEnumerable<User> Users { get; set; }
        public PageView PageView { get; set; }
    }
}
