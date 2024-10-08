using Application.DTOs.Products;
using Application.Products;
using Application.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;
[Route("Product")]
public class ProductController(IMediator mediator): ControllerBase
{
    [Route("Products")]
    [HttpGet]
    public async Task<IActionResult> GetProductsList([FromQuery] GetProductListQuery query)
    {
        var result =await mediator.Send(query);
        return Ok(result);
    }

    [Route("{id:long}")]
    [HttpGet]
    public async Task<IActionResult> GetProduct([FromRoute] long id)
    {
        var result = await mediator.Send(new GetProductQuery(id));
        return Ok(result);
    }

    [Route("{id:long}/update")]
    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromRoute] long id,[FromBody] UpdateProductCommandDTO dto)
    {
        await mediator.Send(new UpdateProductCommand(id,dto));
        return Ok();
    }
}