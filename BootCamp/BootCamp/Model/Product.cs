using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Model
{
    public class Product
    {
        public String Name { get; set; }

        public Product(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null &&
                   Name == product.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
