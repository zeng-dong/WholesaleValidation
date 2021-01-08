using Microsoft.AspNetCore.Mvc;
using WholesaleValidation.Sales;
using WholesaleValidation.Sales.Validations;

namespace WholesaleValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            return Ok("Success!");
        }

        [HttpPut]
        public ActionResult Put([FromBody] Order order)
        {
            var product = new Product
            {
                Name = null // will fail validation
            };

            var validationResult = new ProductValidator().Validate(product);

            /*
            foreach( var er in validationResult.Errors)
            {
                er.
            }
            the FluentValidation.AspNet middleware is preferred, 
            as it “catches” this exception, 
            unpacks the validation errors, 
            and returns a 400 (Bad Request) with a nice response model
            */


            return validationResult.IsValid
                ? (ActionResult)Ok("Success!")
                : BadRequest("Validation failed");
        }
    }
}
