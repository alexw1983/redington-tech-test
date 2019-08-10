namespace RedingtonTechTest.WebAPI.Services.Validation.Interfaces
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T input);
    }
}