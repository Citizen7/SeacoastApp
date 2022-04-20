namespace SeacoastApp.Models;

public interface ISalesUnit {
    int SalesUnitID { get; set; }
    int EmployeeID { get; set; }
    int UnitsSold { get; set; }
}