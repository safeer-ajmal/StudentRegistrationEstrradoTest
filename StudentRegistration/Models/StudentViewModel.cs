using System.ComponentModel.DataAnnotations;

public class StudentViewModel
{
    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Age is required.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "DOB is required.")]
    public DateTime DOB { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string Gender { get; set; }

    
    [EmailAddress]
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone Number is required.")]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public List<Qualification> Qualifications { get; set; }
}
