using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoC.SendEmail.API.Application.Commands.CreateSubscriber;
using PoC.SendEmail.API.Application.Commands.GetAllSubscriber;

namespace PoC.SendEmail.API.Controllers;

[ApiController]
[Route("api/subscribers")]
public class SubscriberController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubscriberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _mediator.Send(new GetAllSubscribersRequest());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscriber([FromBody] CreateSubscriberRequest command)
    {
        try
        {
            var subscriber = await _mediator.Send(command);
            return Ok(subscriber);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
