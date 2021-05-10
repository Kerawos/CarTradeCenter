using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Data
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }


        public PaginatedList()
        {

        }


        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }


        public bool IsPreviousPage
        {
            get { return PageIndex > 1; }
            
        }


        public bool IsNextPage
        {
            get { return PageIndex < TotalPages; }
        }


        public List<T> CreateList(List<T> models, int pageIndex, int pageSize)
        {
            var count = models.Count();
            var items = models.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }



    }
}
