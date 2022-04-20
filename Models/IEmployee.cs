namespace SeacoastApp.Models;

public interface IEmployee {
    int EmployeeID { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Title { get; set; }
    DateTime DateOfHire { get; set; }
}