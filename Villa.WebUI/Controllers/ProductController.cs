using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.DealDtos;
using Villa.Dto.Dtos.ProductDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.TGetListAsync();
            var valueList = _mapper.Map<List<ResultProductDto>>(values);
            return View(valueList);
        }
        public async Task<IActionResult> DeleteProduct(ObjectId id)
        {
            await _productService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            ModelState.Clear();
            var newValue = _mapper.Map<Product>(createProductDto);
            var validator = new ProductValidator();
            var result = validator.Validate(newValue);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(createProductDto);
            }
            await _productService.TCreateAsync(newValue);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateProduct(ObjectId id)
        {
            var value = await _productService.TGetByIdAsync(id);
            var updateValue = _mapper.Map<UpdateProductDto>(value);
            return View(updateValue);
        }
        [HttpPost]

        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var updateValue = _mapper.Map<Product>(updateProductDto);
            await _productService.TUpdateAsync(updateValue);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ProductDetails(ObjectId id)
        {
            var value = await _productService.TGetByIdAsync(id);
            var product = _mapper.Map<ResultProductDto>(value);
            return View(product);
        }
    }
}
