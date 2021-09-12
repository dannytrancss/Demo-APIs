using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Parameters
{
    public class RequestParameter
    {
        const int PAGE_NUMBER_DEFAULT = 1;
        const int PAGE_SIZE_dEFAULT = 10;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public RequestParameter()
        {
            PageNumber = PAGE_NUMBER_DEFAULT;
            PageSize = PAGE_SIZE_dEFAULT;
        }
        public RequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? PAGE_NUMBER_DEFAULT : pageNumber;
            PageSize = pageSize > PAGE_SIZE_dEFAULT ? PAGE_SIZE_dEFAULT : pageSize;
        }
    }
}
