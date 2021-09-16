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
        public long TotalRecords { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize, long totalRecords)
        {
            TotalRecords = totalRecords;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
        public PagedResponse(T data, int pageNumber, int pageSize, long totalRecords, bool isSucceed = true, string message = null)
        {
            TotalRecords = totalRecords;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = message;
            Succeeded = true;
            Errors = null;
        }
    }
}
