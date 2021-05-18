//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AntoniosPizza.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int OrderID { get; set; }

        public System.DateTime OrderDate { get; set; }
        
        [Required]
        [Display(Name ="First Name")]
        [StringLength(60, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        [StringLength(60, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Please enter a valid Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]

        public string Telephone { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]

        [StringLength(100, MinimumLength = 2)]

        public string Address1 { get; set; }

        [Display(Name = "Address Line 2")]

        public string Address2 { get; set; }
        [Required]
        [Display(Name = "Town")]
        [StringLength(30, MinimumLength = 2)]

        public string Town { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(30, MinimumLength = 2)]

        public string City { get; set; }
        [Required]
        [Display(Name = "Postcode")]

        public string Postcode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}