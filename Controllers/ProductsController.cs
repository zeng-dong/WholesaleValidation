using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WholesaleValidation.Sales;
using WholesaleValidation.Sales.Commands;

namespace WholesaleValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("no-error-handling")]
        public ActionResult Post([FromBody] Product product)
        {
            var result = _mediator.Send(new CreateProductCommand { Product = product });

            return Ok(new { Message = "Success", Data = result });
        }

        [HttpPost("error-handling")]
        public async Task<ActionResult> Post_AndHandleError([FromBody] Product product)
        {
            try
            {
                var result = await _mediator.Send(new CreateProductCommand { Product = product });
                return Ok("Success!");
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { data = ex.Data, errors = ex.Errors });

                /*
                 *{
  "data": {},
  "errors": [
    {
      "propertyName": "Product.Code",
      "errorMessage": "'Product. Code' must not be empty.",
      "attemptedValue": "",
      "customState": null,
      "severity": 0,
      "errorCode": "NotEmptyValidator",
      "formattedMessageArguments": [],
      "formattedMessagePlaceholderValues": {
        "PropertyName": "Product. Code",
        "PropertyValue": ""
      }
    },
    {
      "propertyName": "Product.Name",
      "errorMessage": "The length of 'Product. Name' must be 10 characters or fewer. You entered 53 characters.",
      "attemptedValue": "xxxxxxxxxxxxxx yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy",
      "customState": null,
      "severity": 0,
      "errorCode": "MaximumLengthValidator",
      "formattedMessageArguments": [],
      "formattedMessagePlaceholderValues": {
        "MinLength": 0,
        "MaxLength": 10,
        "TotalLength": 53,
        "PropertyName": "Product. Name",
        "PropertyValue": "xxxxxxxxxxxxxx yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy"
      }
    }
  ]
}
                 */

            }
        }
    }
}
