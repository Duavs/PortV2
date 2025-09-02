namespace PortV2.Data;
using System.ComponentModel.DataAnnotations;
public class ContactFormModel
{
    [Required(ErrorMessage = "Name is required.")]
    public string? User { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; set; }

    [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters.")]
    public string? Message { get; set; }
}