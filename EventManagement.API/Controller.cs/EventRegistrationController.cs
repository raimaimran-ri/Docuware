using EventManagement.Application.DTOs;
using EventManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class EventRegistrationController : ControllerBase
{
    private readonly IEventRegistrationService _eventRegistrationService;

    public EventRegistrationController(IEventRegistrationService eventRegistrationService)
    {
        _eventRegistrationService = eventRegistrationService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterForEvent([FromBody] CreateEventRegistrationDTO request)
    {
        try
        {
            var registration = await _eventRegistrationService.CreateEventRegistrationAsync(request);
            return registration ? Ok("Event registration successful.") : BadRequest("Event registration failed.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    [Route("event/{event_id}")]
    public async Task<IActionResult> GetAllRegistrationsForEvent(int event_id)
    {
        try
        {
            var registrations = await _eventRegistrationService.GetEventRegistrationsByEventIdAsync(event_id);
            return Ok(registrations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRegistrations()
    {
        try
        {
            var registrations = await _eventRegistrationService.GetAllEventRegistrationsAsync();
            return Ok(registrations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }   
}