using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Creates Identity column
        public int OrderId { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string UserId { get; set; }

        [Column(TypeName = "INT")]
        [Required]
        public int ProductId { get; set; }

    }
}
