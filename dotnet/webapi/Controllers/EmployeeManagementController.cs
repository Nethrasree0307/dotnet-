using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DB;
using webapi.Model;

namespace webapi.Controllers
{

    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class EmployeeManagementController: ControllerBase
    {
         private readonly AppDBContext _context;
         public EmployeeManagementController(AppDBContext context)
         {
            _context = context;
         }
         [HttpGet]
         [Route("")]
         public async Task<ActionResult<IEnumerable<Employee>>>Get()
         {
         return await _context.Employees.ToListAsync();
         }

         [HttpGet]
         [Route("{id:int:range(1,3)}")]
         public  ActionResult<Employee> GetById(int id)
         {
          try 
          {
           Employee employees = _context.Employees.Find(id);
            if(employees ==null)
              {
                return NotFound();
              }
            return employees;
           }
           catch(Exception ex)
           {
            return StatusCode(500);
           }
         }
                        
         [HttpDelete]
         [Route("{id:int:min(3)}")]
         public async Task<IActionResult>Delete(int id)
           {
           var employee = await _context.Employees.FindAsync(id);
           if (employee == null)
           {
           return NotFound();
           }
           _context.Employees.Remove(employee);
           await _context.SaveChangesAsync();
           return NoContent();
           }
           }
      }







 