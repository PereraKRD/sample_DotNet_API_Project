namespace FormulaOne.Entities.DTOs.Requests;

public class CreateDriverRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int DriverNumber { get; set; }
    public DateTime BirthDate { get; set; }
}