using System.ComponentModel.DataAnnotations;

namespace DateValidator.Models;

public class Survey
{
    [Required]
    [MinLength(2)]
    public string?  Name { get; set; }
    [Required]
    [FutureDate]
    public DateTime? Date { get; set; }
    [Required]
    public string? Location { get; set; }
    [Required]
    public string? Language { get; set; }
    [MinLength(20)]
    public string? Comment { get; set; }

}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime)
        {
            if ((DateTime)value < DateTime.Now)
            {
                return ValidationResult.Success;
            }
        }
        return new ValidationResult("La fecha debe ser anterior a la fecha actual.");
    }
}