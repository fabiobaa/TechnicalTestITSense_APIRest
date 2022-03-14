using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataBase
{
    public partial class StatusProduct
    {
        public StatusProduct()
        {
            Products = new HashSet<Product>();
        }

        public int idStatusProduct { get; set; }
        public string nameStatusProduct { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
