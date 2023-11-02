using API.Dtos.Request;
using API.Dtos.Response;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductDomain _domain;
        private readonly IMapper _mapper;

        public ProductController(IProductDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var services = await _domain.GetAllProducts();
            var result = _mapper.Map<List<Product>, List<ProductResponseDto>>(services);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _domain.GetProductById(id);
            if (service == null) return NotFound();
            var result = _mapper.Map<Product, ProductResponseDto>(service);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _domain.DeleteProduct(id);
            if (!isDeleted) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductCreateDto productUpdate)
        {
            var result = _mapper.Map<ProductCreateDto, Product>(productUpdate);
            var isUpdated = await _domain.UpdateProduct(id, result);
            if (!isUpdated) return BadRequest();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateDto service)
        {
            var result = _mapper.Map<ProductCreateDto, Product>(service);
            var isCreated = await _domain.CreateProduct(result);
            if (!isCreated) return BadRequest();
            return Ok(result);
        }
    }
}
