using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Qualification
{
    public int QualificationId { get; set; }

    public string Course { get; set; }
    public string University { get; set; }
    public int Year { get; set; }
    public float Percentage { get; set; }

    public int StudentId { get; set; }
    [ValidateNever]
    public Student Student { get; set; }
}
