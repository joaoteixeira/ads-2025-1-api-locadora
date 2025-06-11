using ApiLocadora.DataContexts;
using ApiLocadora.Services;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Validations
{
    public class CheckEntityExistAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        private readonly AppDbContext _context;


        public CheckEntityExistAttribute()
        {
            //string comparisonProperty,
            //_comparisonProperty = comparisonProperty;
            //_context = context;

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
            FilmeService? service = validationContext.GetService(typeof(FilmeService)) as FilmeService;
           
            var currentValue = (int) value;

            if (service == null)
            {
                return new ValidationResult(ErrorMessage = "O gênero informado não foi encontrado!");
            }

            var exist = service.GetOneByIdG(currentValue);
            Console.WriteLine("AQUI " + exist.ToString());

            if (!exist)
            {
                return new ValidationResult(ErrorMessage = "O gênero informado não foi encontrado!");
            }


            //return new ValidationResult(ErrorMessage = "O gênero informado não foi encontrado!");
            return ValidationResult.Success;
        }
    }
}