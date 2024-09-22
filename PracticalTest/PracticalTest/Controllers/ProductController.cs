using Microsoft.AspNetCore.Mvc;
using PracticalTest.Errors;
using PracticalTest.Manager.Contract;
using PracticalTest.Manager.EntityDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            return Ok(await _productService.GetAllAsync());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDto productDto)
        {
            var saved = await _productService.AddAsync(productDto);
            return Ok(new ApiResponse(201, "Data Saved"));
        }
    }
}
