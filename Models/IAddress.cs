namespace SeacoastApp.Models;

public interface IAddress {
    int AddressID { get; set; }
    int EmployeeID { get; set; }
    string Address1 { get; set; }
    string? Address2 { get; set; }
    string Zip { get; set; }
    string Phone { get; set; }
    string Email { get; set; }
}