using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Pagination
    {
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}