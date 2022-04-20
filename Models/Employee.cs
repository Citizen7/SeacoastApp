using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeacoastApp.Models;

public class Employee : IEmployee {
    [Key]
    public int EmployeeID { get; set; }
    [Required]
    [DisplayName("First Name")]
    public string FirstName { get; set; }
    [Required]
    [DisplayName("Last Name")]
    public string LastName { get; set; }
    [Required]
    public string Title { get; set; }
    [DisplayName("Date of Hire")]
    public DateTime DateOfHire { get; set; }
}