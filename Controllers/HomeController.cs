using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SeacoastApp.Data;
using SeacoastApp.Models;

namespace SeacoastApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        // Create a joined query that includes SalesUnit data with the Employee record
        var query = _db.Employees
            .Join(
                _db.SalesUnits,
                x => x.EmployeeID, // join where EmployeeID numbers match
                y => y.EmployeeID,
                (x, y) => new
                {
                    EmployeeID = x.EmployeeID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Title = x.Title,
                    TotalUnits = y.UnitsSold,
                    DateOfHire = x.DateOfHire.ToShortDateString() // Display only the date. Time isn't relevant here
                }
            ).ToList();        
        // Send the results to the view
        return View(query);
    }

    public IActionResult EmpProfile(int? empId)
    {
        // Check that a valid ID is available
        if (null==empId || empId == 0)
            return NotFound();
        
        // Assign view model
        EmpProfile m = new EmpProfile();
        // * ASSUMPTION: Only one record exists per table per EmployeeID * //
        m.Employee = _db.Employees.First(x => x.EmployeeID == empId);
        m.EmployeeID = empId.Value;
        // * ASSUMPTION: Only one record exists per table per EmployeeID * //
        m.Address = _db.Addresses.First(x => x.EmployeeID == empId);
        m.AddressID = m.Address.AddressID;
        // * ASSUMPTION: Only one record exists per table per EmployeeID * //
        m.SalesUnit = _db.SalesUnits.First(x => x.EmployeeID == empId);
        m.SalesUnitID = m.SalesUnit.SaleUnitID;

        // Check that employee data was found
        if (null == m.Employee)
            return NotFound();
        // TODO: Consider adding null checks for Address and SalesUnits tables as well.

        return View(m);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EmpProfile(EmpProfile obj)
    {
        
        // Validate the model
        // TODO: resolve situation where returned model does not maintain ID values, leading to fringe behavior
        if(obj.AddressID == 0 || obj.EmployeeID == 0 || obj.SalesUnitID == 0)
            ModelState.AddModelError("CustomError", "A known error has occured. Please refresh the page.");
        if(ModelState.IsValid)
        {
            _db.Employees.Update(obj.Employee);
            _db.Addresses.Update(obj.Address);
            _db.SalesUnits.Update(obj.SalesUnit);
            _db.SaveChanges();
            // If the record was updated, return to index
            return RedirectToAction("Index");

        }
        // If the model is not valid, return the view for changes.
        return View(obj);
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
