namespace Itmo.ObjectOrientedProgramming.Lab2;
public class WarrantyValidationError
{
    public WarrantyValidationError(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public string ErrorMessage { get; set; }
}