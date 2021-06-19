using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Examples
{
    public class PaginateProperties
    {

        public int? PageIndex { get; set; }
        public string SortBy { get; set; }
        public int? Order { get; set; }
        public int? PageSize { get; set; }
        public int? RecordsCount { get; set; }
    }
}
