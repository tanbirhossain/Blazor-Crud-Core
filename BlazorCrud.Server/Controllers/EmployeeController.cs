using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCrud.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrud.Server.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> employeesList = new List<Employee>();
        public EmployeeController ()
        {
            if (employeesList.Count == 0 )
            {
                employeesList.Add(new Employee { EmployeeId = 1, Name = "Ovi", City = "Dhaka", Department = "Cse", Gender = "Male" });
            }

        }

        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<Employee> Index()
        {
            return employeesList.ToList();
        }
        [HttpPost]
        [Route("api/Employee/Create")]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            var result = employeesList.Max(e=>e.EmployeeId);

            employee.EmployeeId = result + 1;
            employeesList.Add(employee);
            return Ok(employee);
        }
        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public Employee Details(int id)
        {
            return employeesList.Where(e=>e.EmployeeId == id).FirstOrDefault();
        }
        [HttpPut]
        [Route("api/Employee/Edit")]
        public void Edit([FromBody]Employee employee)
        {
            var result = employeesList.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();
            result.Name = employee.Name;
        }
        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public void Delete(int id)
        {
           var result =  employeesList.Where(e => e.EmployeeId == id).FirstOrDefault();
            employeesList.Remove(result);
        }
    }

    public static class UpdateExtensions
    {
        public delegate void Func<TArg0>(TArg0 element);

        public static int Update<TSource>(this IEnumerable<TSource> source, Func<TSource> update)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (update == null) throw new ArgumentNullException("update");
            if (typeof(TSource).IsValueType)
                throw new NotSupportedException("value type elements are not supported by update.");

            int count = 0;
            foreach (TSource element in source)
            {
                update(element);
                count++;
            }
            return count;
        }
    }
}