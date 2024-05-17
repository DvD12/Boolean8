using System.ComponentModel.DataAnnotations;

namespace PizzaMvc.Models
{
    public class MinWordsAttribute : ValidationAttribute
    {
        public int MinimumWords { get; set; }
        public MinWordsAttribute(int minimumWords)
        {
            this.MinimumWords = minimumWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            var parole = fieldValue?.Split(' ');
            if (parole?.Where(s => s.Length > 0).Count() < MinimumWords)
            {
                return new ValidationResult($"Il campo deve contenere almeno {MinimumWords} parole");
            }

            return ValidationResult.Success;
        }
    }
}
