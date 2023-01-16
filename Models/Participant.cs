using System.ComponentModel.DataAnnotations;

namespace EventAppEFCore.Models
{
    public enum PaymentType
    { Sularaha, Ülekanne }
    public class Participant
    {
        public int ID { get; set; }
        [Required]
        public byte IsCompany { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public EventInfo? EventInfo { get; set; } 

    }
    public class PrivateParticipant : Participant
    {
        [Required]
        [StringLength(100)]
        public string? FName { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string? LName { get; set; } = string.Empty;
        [Required]
        [StringLength(11)]
        [RegularExpression("^[0-9]+$")]
        //[NumberValidator]
        public string PersonalIdNumber { get; set; } = string.Empty;
        [Required]
        [StringLength(1500)]
        public string AdditionalInfo { get; set; } = string.Empty;

    }
    public class CompanyParticipant : Participant
    {
        [Required]
        [StringLength(11)]
        [RegularExpression("^[0-9]+$")]
        public string CoCode { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string CoName { get; set; } = string.Empty;
        [Required]
        [StringLength(1000)]
        [RegularExpression("^[0-9]+$")]
        public string CoParticipants { get; set; } = string.Empty;
        [Required]
        [StringLength(5000)]
        public string AdditionalInfo { get; set; } = string.Empty;

    }
    // Here we validate personal ID code
    //public class NumberValidator : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        int[] multipliers1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
    //        int[] multipliers2 = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };
    //        string PersonalIdNumber = (string)value;
    //        int checkDigit = PersonalIdNumber[9];
    //        Console.WriteLine(checkDigit);

    //        //if (number < 0 || number > 100)
    //        //{
    //        //    return new ValidationResult("Palun kontrolli isikukood üle.");
    //        //}

    //        return ValidationResult.Success;
    //    }
    //}
}
