using System.ComponentModel.DataAnnotations;

namespace Dell.CustomerService.Web.ApiContracts.Customers
{
    public class CustomerRequestData
    {
		[MaxLength(ErrorMessage = "E-mail cannot be more than 50 characters.")]
		[Required(ErrorMessage = "E-mail cannot be empty.")]
		[EmailAddress(ErrorMessage = "Invalid E-mail address.")]
		public string Email { get; set; }

	    [Required(ErrorMessage = "Name cannot be empty.")]
	    [MaxLength(ErrorMessage = "Name cannot be more than 50 characters.")]
		public string Name { get; set; }		
    }
}
