using NikamoozStore.Core.Domain.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikamoozStore.EndPoints.WebUI.Models.Carts
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
