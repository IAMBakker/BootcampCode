using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Model
{
    public class WishList
    {
        public String Name { get; set; }
        public int Items { get; set; }

        public WishList(String name, int items)
        {
            Name = name;
            Items = items;
        }

        public override bool Equals(object obj)
        {
            var list = obj as WishList;
            return list != null &&
                   Name == list.Name &&
                   Items == list.Items;
        }

        public override int GetHashCode()
        {
            var hashCode = 5743141;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Items.GetHashCode();
            return hashCode;
        }
    }
}
