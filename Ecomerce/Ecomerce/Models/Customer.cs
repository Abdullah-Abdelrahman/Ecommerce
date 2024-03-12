using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Governorate is required.")]
        public string? Governorate { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]
        [StringLength(10, ErrorMessage = "Postal code must be between 1 and 10 characters.", MinimumLength = 1)]
        public string? PostalCode { get; set; }

        public string? AdditionalAddressInfo { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Display(Name = "Text me with news and offers")]
        public bool IsNewsOn { get; set; }

      
        public Order Order { get; set; }
    }
}
