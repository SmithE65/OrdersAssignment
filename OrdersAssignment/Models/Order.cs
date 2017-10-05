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
        public int Id { get; set; }                     // Primary key & unique identifier

        [Required]
        [StringLength(20)]
        public string OrderNbr { get; set; }            // alphanumeric order number (should this be unique?)

        [Required]
        public DateTime DateReceived { get; set; }      // date-time order is received

        [Required]
        public int CustomerId { get; set; }             // customer that placed the order
        public virtual Customer Customer { get; set; }  // contains cusomer information

        [Required]
        public decimal Total { get; set; } // type double in spec

        [Required]
        public bool IsDeleted { get; set; } // have we been deleted yet?
    }
}