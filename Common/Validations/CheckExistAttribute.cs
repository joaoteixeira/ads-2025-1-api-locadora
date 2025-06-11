using ApiLocadora.Services;
using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Common.Validations
{
    public class CheckExistAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            EstudioService? service = validationContext.GetService(typeof(EstudioService)) as EstudioService;

            if(service == null)
            {
                return new ValidationResult(ErrorMessage = "Não possível consultar o estudio");
            }

            int id = (int)value;

            if (!service.Exist(id))
            {
                return new ValidationResult(ErrorMessage = "Estudio não encontrado");
            }

            return ValidationResult.Success;
        }
    }
}
