using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {    private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
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
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Özellik Silindi");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
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
        [HttpGet("GetProductsWithCategories")]
        public IActionResult GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new GetProductsWithCategories
            {
                Description = y.Description,
                ImageUrl= y.ImageUrl,
                Price= y.Price,
                ProductID= y.ProductID,
                ProductStatus= y.ProductStatus,
                ProductName= y.ProductName,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
        }
    }
}
