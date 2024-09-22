using Microsoft.AspNetCore.Mvc;
using PracticalTest.Entities.Entites;
using PracticalTest.Errors;
using PracticalTest.Manager.Contract;
using PracticalTest.Manager.EntityDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly ICustomerService _customerService;

        public SaleController(ISaleService saleService, ICustomerService customerService)
        {
            _saleService = saleService;
            _customerService = customerService;
        }

        // GET: api/<ProductController>
        [HttpGet("GetSaleDetailsAsync")]
        public async Task<ActionResult<List<SaleDetail>>> GetSaleDetailsAsync()
        {
            return Ok(await _saleService.GetSaleDetailsAsync());
        }
        // GET: api/<ProductController>
        [HttpGet("GetSaleDetailsByCustomerNameAsync/{userName}")]
        public async Task<ActionResult<List<SaleDetail>>> GetSaleDetailsByCustomerIdAsync(string userName)
        {
            return Ok(await _saleService.GetSaleDetailsByCustomerNameAsync(userName));
        }
        // GET: api/<ProductController>
        [HttpGet("GetSaleDetailByIdAsync/{id}")]
        public async Task<ActionResult<List<SaleDetail>>> GetSaleDetailByIdAsync(int id)
        {
            return Ok(await _saleService.GetSaleDetailByIdAsync(id));
        }

        [HttpGet("GetSaleCustomerAsync")]
        public async Task<ActionResult<List<CustomerDto>>> GetSaleCustomerAsync()
        {
            return Ok(await _customerService.GetAllAsync());
        }


        // GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductDto>> Get(int id)
        //{
        //    return await _productService.GetByIdAsync(id);
        //}

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SaleDto dto)
        {

            var saved = await _saleService.AddWithCustomerAsync(dto);
            return Ok(new ApiResponse(201, "Data Saved"));
        }
    }
}
