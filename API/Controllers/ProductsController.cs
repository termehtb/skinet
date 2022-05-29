
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifcation;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]

public class ProductsController : BaseApiController
{
    
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

    public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> brandRepo, IGenericRepository<ProductType> typeRepo, IMapper mapper)
    {
            _mapper = mapper;
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
       
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProducSpectPrams produstPrams )
    {
        var spec = new ProoductsWithTypesAndBrandSpecification(produstPrams);
        var countSpec = new ProductWithFiltersForCountSpecification(produstPrams);
        var totalItems = await _productRepo.CountAsync(countSpec);
        var products = await _productRepo.ListAsync(spec);
        var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
        return Ok(new Pagination<ProductToReturnDto>(produstPrams.PageIndex, produstPrams.PageSize, totalItems, data));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id){

        var spec = new ProoductsWithTypesAndBrandSpecification(id);
        var product = await _productRepo.GetEntityWithSpec(spec);
        if (product == null) return NotFound(new ApiResponse(404));
        return _mapper.Map<Product, ProductToReturnDto>(product);

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