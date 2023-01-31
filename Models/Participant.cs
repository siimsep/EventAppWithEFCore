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
        [RegularExpression("^[A-Za-zõäöü]+$", ErrorMessage = "Eesnimi peab sisaldama ainult tähti.")]
        public string? FName { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        [Display(Name = "Perenimi:")]
        [RegularExpression("^[A-Za-zõäöü]+$", ErrorMessage = "Perenimi peab sisaldama ainult tähti.")]
        public string? LName { get; set; } = string.Empty;
        [Required]
        [StringLength(11)]
        //[MinLength(11, ErrorMessage = "Isikukood peab koosnema 11-st numbrist.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Isikukood peab sisaldama ainult numbreid.")]
        [Display(Name = "Isikukood:")]
        [NumberValidator(ErrorMessage = "Isikukood ei ole korrektne.")]
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
        [RegularExpression("^[0-9]+$", ErrorMessage = "Registrikood peab sisaldama ainult numbreid.")]
        [Display(Name = "Registrikood:")]
        public string CoCode { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        [Display(Name = "Firma nimi:")]
        public string CoName { get; set; } = string.Empty;
        [Required]
        [StringLength(4)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Osalejate arv peab olema arv.")]
        [Display(Name = "Osalejate arv:")]
        public string CoParticipants { get; set; } = string.Empty;
        [Required]
        [StringLength(5000)]
        [Display(Name = "Lisainfo:")]
        public string AdditionalInfo { get; set; } = string.Empty;

    }
    // Here we validate personal ID code
    public class NumberValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // needed for calculating checkdigit
            int[] multipliers1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            int[] multipliers2 = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            
            // personal id number converted to an array
            int[] personalIdNumber = value.ToString().Select(x => int.Parse(x.ToString())).ToArray();
            // control number extraction
            int checkDigit = personalIdNumber[10]; 
            int calculatedCheckDigit = 0;  
            int count = 0; 
            // first multipliers times personal id number
            for (int i = 0; i < personalIdNumber.Length - 1; i++)
            {
                count += personalIdNumber[i] * multipliers1[i];
            }
            int remainder = count % 11;
            // if remainder is 10, need to multiply with second set of multipliers
            if (remainder == 10)
            {
                // reseting count
                count = 0;
                // 2nd multipliers times personal id number
                for (int i = 0; i < personalIdNumber.Length - 1; i++)
                {
                    count += personalIdNumber[i] * multipliers2[i];
                }
                // new remainder
                remainder = count % 11; 
                // if new remainder is still 10, checkdigit = 0
                if (remainder == 10)
                {
                    calculatedCheckDigit = 0;
                }
            } else
            {
                calculatedCheckDigit = remainder;
            }
            if (calculatedCheckDigit == checkDigit){
                Console.WriteLine("calc = check" + calculatedCheckDigit + "" + checkDigit);
                return ValidationResult.Success;

            }
            return new ValidationResult(ErrorMessage);

        }
    }
}
