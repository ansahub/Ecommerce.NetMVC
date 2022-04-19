using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ProductApi.Models
{
    [Table("Category")]
    public class Category
    {
        [Key] //Makes CategoryId PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Creates Identity column
        public int CategoryId { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string CategoryName { get; set; }

    }
}
