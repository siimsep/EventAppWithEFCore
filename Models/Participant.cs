using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAppEFCore.Models
{
    
    public class Participant
    {
        public int ID { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Maksmisviis:")]
        public string PaymentType { get; set; } = string.Empty;
        [ForeignKey("EventInfoId")]
        public int EventInfoId { get; set; }

    }
    public class PrivateParticipant : Participant
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Eesnimi:")]
        public string? FName { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        [Display(Name = "Perenimi:")]
        public string? LName { get; set; } = string.Empty;
        [Required]
        [StringLength(11)]
        [RegularExpression("^[0-9]+$")]
        [Display(Name = "Isikukood:")]
        //[NumberValidator]
        public string PersonalIdNumber { get; set; } = string.Empty;
        [Required]
        [StringLength(1500)]
        [Display(Name = "Lisainfo:")]
        public string AdditionalInfo { get; set; } = string.Empty;


    }
    public class CompanyParticipant : Participant
    {
        [Required]
        [StringLength(11)]
        [RegularExpression("^[0-9]+$")]
        [Display(Name = "Registrikood:")]
        public string CoCode { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        [Display(Name = "Firma nimi:")]
        public string CoName { get; set; } = string.Empty;
        [Required]
        [StringLength(4)]
        [RegularExpression("^[0-9]+$")]
        [Display(Name = "Osalejate arv:")]
        public string CoParticipants { get; set; } = string.Empty;
        [Required]
        [StringLength(5000)]
        [Display(Name = "Lisainfo:")]
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
