using Microsoft.AspNetCore.Mvc;
using ShopSystem.Domain.Models;
using ShopSystem.Services;

namespace ShopSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ShopSystemDemoBaseController<Product,int,ProductItem,ProductOutput,ProductInput,ProductUpdate>
{
    public ProductController(ProductService service):base(service)
    {

    }
}
