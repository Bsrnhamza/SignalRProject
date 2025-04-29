using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {    private readonly IProductService _featureService;
        private readonly IMapper _mapper;

        public ProductController(IProductService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_featureService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _featureService.TAdd(new Product()
            {
                ProductName = createProductDto.ProductName,
                ProductStatus = createProductDto.ProductStatus,
                Price = createProductDto.Price,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl
            });
            return Ok("Özellik Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _featureService.TGetByID(id);
            _featureService.TDelete(value);
            return Ok("Özellik Silindi");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _featureService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _featureService.TUpdate(new Product()
            {
                ProductID = updateProductDto.ProductID,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus,
                Price = updateProductDto.Price,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
            });
            return Ok("Özellik Güncellendi");
        }
    }
}
