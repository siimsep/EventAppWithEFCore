using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAppEFCore.Models
{
    public class EventInfo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name = "Ürituse nimi:")]
        public string EventName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        [BindProperty, DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = false)]
        [FutureDate]
        [Display(Name = "Toimumisaeg:")]
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        [Required]
        [StringLength(1000, MinimumLength = 2)]
        [Display(Name = "Koht:")]
        public string EventLocation { get; set; } = string.Empty;
        [Required]
        [StringLength(1000)]
        [Display(Name = "Lisainfo:")]
        public string EventMemo { get; set; } = string.Empty;
    }
    // Validate if date is indeed in the future
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value,
            ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;
            if (date.Date >= DateTime.Now.Date)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Kuupäev peab olema tulevikus");
        }
    }
}
   
