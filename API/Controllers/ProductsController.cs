
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository Repo;

    public ProductsController(IProductRepository repo)
    {
        Repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await Repo.GetProductsAsync();
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProducts(int id){
        return await Repo.GetProductByIDAsync(id);
    }
}