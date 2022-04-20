using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeacoastApp.Models;

public class SalesUnit {
    [Key]
    public int SaleUnitID { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeID { get; set; }
    [Required]
    [DisplayName("Total Units")]
    public int UnitsSold { get; set; }
}