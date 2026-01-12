using Microsoft.AspNetCore.Mvc;
using technical_test_sigma.Application.Interfaces.Customer;
using technical_test_sigma.DTO.CustomerDto;

namespace technical_test_sigma.Api.Controllers.CustomerControllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Registro completo del cliente (datos + dirección + pago)
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDto dto)
        {
            var customerId = await _customerService.CreateCustomerAsync(dto);
            return Ok(new { CustomerId = customerId });
        }

        /// <summary>
        /// Consulta del estado del cliente
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomerStatus(Guid id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            return Ok(customer);
        }

        /// <summary>
        /// Activar o desactivar un cliente
        /// </summary>
        [HttpPut("{id:guid}/status")]
        public async Task<IActionResult> ChangeCustomerStatus(
            Guid id,
            [FromBody] CustomerStatusDto dto)
        {
            await _customerService.ChangeStatusAsync(id, dto.Active);
            return NoContent();
        }


    }
}
