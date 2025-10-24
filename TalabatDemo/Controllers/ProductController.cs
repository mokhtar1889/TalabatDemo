using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatDemo.Models;

namespace TalabatDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Products> GetProduct(int id) {

            return new Products() {Id= id } ;
        }

        [HttpPost]
        public ActionResult<Products> AddProduct(Products product)
        {

            return new Products();
        }

        [HttpPost("Brand")] //baseurl/api/product/brand
        public ActionResult<Products> AddBrand(Products product)
        {

            return new Products();
        }

        [HttpPut]
        public ActionResult<Products> UpdateProduct(Products product)
        {

            return new Products();
        }

        [HttpDelete]
        public ActionResult<Products> DeleteProduct(Products product)
        {

            return new Products();
        }

    }
}
