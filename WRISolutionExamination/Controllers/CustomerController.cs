using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Services.BusinessServices;
using System.ComponentModel.DataAnnotations;

namespace WRISolutionExamination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required] int page, [Required] int count)
        {
            try
            {
                var result = await _customerService.GetCustomersAsync(page, count);
                return StatusCode(200, result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Customer customer)
        {
            try
            {
                var result = await _customerService.AddCustomerAsync(customer);

                if (!result)
                {
                    return StatusCode(400);
                }

                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500, "Internal Service Error!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([Required] int id, [FromBody] Customer customer)
        {
            try
            {
                var result = await _customerService.EditCustomerAsync(id, customer);

                if (!result)
                {
                    return StatusCode(404);
                }

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
