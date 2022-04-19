using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    [Table("Carts")]
    public class Cart
    {
        [Key] //Makes CartId PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Creates Identity column
        public int CartId { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string UserId { get; set; }

        [Column(TypeName = "INT")]
        [Required]
        public int ProductId { get; set; }
    }
}

