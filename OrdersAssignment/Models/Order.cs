using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrdersAssignment.Models
{
    /// <summary>
    /// Model of Order table in database
    /// </summary>
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string OrderNbr { get; set; }

        [Required]
        public DateTime DateReceived { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public decimal Total { get; set; } // type double in spec
    }
}