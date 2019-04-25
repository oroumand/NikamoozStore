using NikamoozStore.Core.Domain.Products;
using NikamoozStore.EndPoints.WebUI.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikamoozStore.EndPoints.WebUI.Models.Products
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
