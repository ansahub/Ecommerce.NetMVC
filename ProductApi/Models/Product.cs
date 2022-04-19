using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Ecommerce.ProductApi.Models
{
    [Table("Item")]
    public class Product
    {
        [Key] //Makes ProductId PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }


        [Column(TypeName = "varchar(100)")]
        [Required]
        public string ProductName { get; set; }


        [Column(TypeName = "INT")]
        [Required]
        public int ProductPrice { get; set; }

        [Column(TypeName = "INT")]
        [Required]
        public int CategoryId { get; set; }


    }
}
