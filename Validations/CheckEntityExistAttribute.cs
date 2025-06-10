using ApiLocadora.DataContexts;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Validations
{
    public class CheckEntityExistAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        private readonly AppDbContext _context;


        public CheckEntityExistAttribute(AppDbContext context)
        {
            //string comparisonProperty,
            //_comparisonProperty = comparisonProperty;
            _context = context;

            //serviceProvider = AppDependencyResolver.Current.GetService<IServiceProvider>();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var currentValue = (DateTime)value;

            //var comparisonValue = (DateTime)validationContext.ObjectType.GetProperty(_comparisonProperty)
            //                                                            .GetValue(validationContext.ObjectInstance);

            //if (currentValue < comparisonValue)
            //{
            //    return new ValidationResult(ErrorMessage = "End date must be later than start date");
            //}

            var currentValue = (int) value;

            var exist = _context.Generos.Where(x => x.Id == currentValue).Any();

            if (!exist)
            {
                return new ValidationResult(ErrorMessage = "O gênero informado não foi encontrado!");
            }

            return ValidationResult.Success;
        }
    }
}