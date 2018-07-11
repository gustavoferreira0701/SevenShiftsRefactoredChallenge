using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevenShifts.Application.Contracts;

namespace SevenShifts.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeApp;

        public EmployeeController(IEmployee employeeApp)
        {
            _employeeApp = employeeApp;
        }

        [HttpGet, Route("data/{userid}")]
        public async Task<IActionResult> GetEmployeeData(int userid)
        {
            try
            {
                var result = await _employeeApp.GetEmployeeData(userid);

                if (result == null)
                    return NotFound();
                else
                    return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}