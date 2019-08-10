namespace RedingtonTechTest.WebAPI.Services.Validation
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }

        public string Error { get; set; }

        protected ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Error = message;
        }

        public static ValidationResult Success()
        {
            return new ValidationResult(true, null);
        }

        public static ValidationResult Fail(string message)
        {
            return new ValidationResult(false, message);
        }
    }
}
