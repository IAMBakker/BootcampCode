using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Model
{
    public class FillableWishList : WishList
    {
        public IList<Product> Products { get; set; }

        public FillableWishList(string name, bool isDefault)
            : base(name, 0, isDefault)
        {
            Name = name;
            Products = new List<Product>();
            IsDefault = isDefault;
        }

        public FillableWishList addProduct(Product product)
        {
            Products.Add(product);
            Items = Products.Count;
            return this;
        }
    }
}
