using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCRM.Web
{
    public class PageViewModel<T> where T : class
    {
        private const int pageSize = 6;

        public List<T> ListData { get; private set; }

        public int PageNumber { get; private set; }

        public int TotalPages { get; private set; }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);

            }
        }

        public PageViewModel(int pageNumber, List<T> data)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(data.Count / (double)pageSize);
            ListData = data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(); ;
        }
    }
}
