namespace SeacoastApp.Models;

public class EmpProfile
{
    public int EmployeeID { get; set; }
    public Employee Employee { get; set; }

    public int AddressID { get; set; }
    public Address Address { get; set; }

    public int SalesUnitID { get; set; }
    public SalesUnit SalesUnit { get; set; }
}