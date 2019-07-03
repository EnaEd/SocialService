using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.ServiceLogic.ViewModels
{
    public class PageView
    {
        private const int DEFAULT_PAGE = 1;

        public PageView(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
        }
        public int PageNumber { get; set; }
        public int TotalPage { get; set; }
        public bool HasPrevius
        {
            get
            {
                return PageNumber > DEFAULT_PAGE;
            }
        }
        public bool HasNext
        {
            get
            {
                return PageNumber < TotalPage;
            }
        }

    }
}
