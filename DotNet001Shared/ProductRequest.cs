using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet001Shared
{
    public class ProductRequest
    {
        public string? Search { get; set; }
        public bool? IsDeleted { get; set; }

        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public int PageDefault = 0;

        public int PageSizeDefault = 1;

    }
}
