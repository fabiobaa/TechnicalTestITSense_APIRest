using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models.Product
{
    public class ProductDTO
    {
        public long IdProduct { get; set; }
        public int IdStatusProduct { get; set; }
        public string NameStatusProduct { get; set; }
        public string NameProduct { get; set; }
        public DateTime DateEntryProduct { get; set; }
        public DateTime? DateExitProduct { get; set; }
    }

    public class UpdateProductDTO
    {
        [Required]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Only accepts number and cannot start with 0")]
        public long IdProduct { get; set; }
        
        [Required]
        [Range(1, 2, ErrorMessage = "Only accept 1,2,3 and 4")]
        public int IdStatusProduct { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(50, ErrorMessage = "The maximum length allowed is 50 characters")]        
        public string NameProduct { get; set; }
        
        public DateTime? DateExitProduct { get; set; }
    }
}
