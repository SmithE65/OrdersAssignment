using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrdersAssignment.Models
{
    /// <summary>
    /// Model for Customer table in database
    /// </summary>
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public decimal CreditLimit { get; set; }  // type double in specs

        [Required]
        public bool IsDeleted { get; set; }  // have we been deleted yet???
    }
}