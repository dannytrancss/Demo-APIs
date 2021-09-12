using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Parameters
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
        public PagedResponse(T data, int pageNumber, int pageSize, bool isSucceed = true, string message = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = message;
            Succeeded = true;
            Errors = null;
        }
    }
}
