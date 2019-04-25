using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikamoozStore.EndPoints.WebUI.Models.Commons
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages =>
        (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
