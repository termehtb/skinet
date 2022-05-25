
using Core.Entities;
using Core.Interfaces;
using Core.Specifcation;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<Product> _productRepo;

    public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> brandRepo, IGenericRepository<ProductType> typeRepo)
    {
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
       
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var spec = new ProoductsWithTypesAndBrandSpecification();
        var products = await _productRepo.ListAsync(spec);
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id){

        var spec = new ProoductsWithTypesAndBrandSpecification(id);
        return await _productRepo.GetEntityWithSpec(spec);

    }

    [HttpGet("brands")]
    public async Task<ActionResult<ProductBrand>> GetBrands(){
        return Ok (await _brandRepo.ListAllAync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<ProductType>> GetTypes(){
        return Ok (await _typeRepo.ListAllAync ());
    }
}