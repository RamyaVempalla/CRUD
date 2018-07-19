using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpProtocols.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpProtocols.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public List<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>()
         {
                new EmployeeModel()
                 {
                    id = 1,
                    Name = "Ramya",
                    Salary = 500000,
                    EmailId = "ramyavempalla@gmail.com"
                 },
                new EmployeeModel()
                 {
                    id = 2,
                    Name = "Aruna",
                    Salary = 500000,
                    EmailId = "aruna@gmail.com"
                 }
         };
         
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Employees);
        }

         
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            var emp = Employees.FirstOrDefault(e => e.id == id);
            if (emp != null)
                return Ok(Employees);
            else
                return NotFound();
        }

      
        [HttpPost]
        public ActionResult Post(EmployeeModel employee)
        {
            Employees.Add(employee);
            return Ok(Employees);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private class ApiControllerAttribute : Attribute
        {
        }
    }


}
