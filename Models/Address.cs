using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeacoastApp.Models;

public class Address : IAddress {
    [Key]
    public int AddressID { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeID { get; set; }
    [Required]
    [DisplayName("Address 1")]
    public string Address1 { get; set; }
    [DisplayName("Address 2")]
    public string? Address2 { get; set; }
    public string Zip { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}