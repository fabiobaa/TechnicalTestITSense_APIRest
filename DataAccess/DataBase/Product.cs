using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataBase
{
    public partial class Product
    {
        public long idProduct { get; set; }
        public int idStatusProduct { get; set; }
        public string nameProduct { get; set; }
        public DateTime dateEntryProduct { get; set; }
        public DateTime? dateExitProduct { get; set; }

        public virtual StatusProduct idStatusProductNavigation { get; set; }
    }
}
