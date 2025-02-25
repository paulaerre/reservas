using Microsoft.AspNetCore.Mvc;
using ReservasAPI.Models;
using ReservasAPI.Services;

namespace ReservasAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly ILogger<AppointmentController> _logger;
    private readonly IAppointmentService _service;
    public AppointmentController(ILogger<AppointmentController> logger, IAppointmentService appointmentService)
    {
        _logger = logger;
        _service = appointmentService;
    }

    /// <summary>
    /// 2. Get que devuelva todas las reservas generadas.
    /// </summary>
    [HttpGet]
    [Route("/appointments")]
    public async Task<ActionResult<IEnumerable<Appointment>>> Get()
    {
        try
        {
            return Ok(await _service.Get());
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 2. Get que devuelva los horarios disponibles.
    /// </summary>
    [HttpGet]
    [Route("/appointments/timeslots")]
    public async Task<ActionResult<IEnumerable<string>>> Get([FromQueryAttribute] DateTime date)
    {
        try
        {
            return Ok(await _service.Get(date));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 2. Post que reciba la reserva, valide y devuelva si la operación fue exitosa.
    /// </summary>
    [HttpPost]
    [Route("/appointment")]
    public async Task<ActionResult> Post([FromBody] AppointmentRequest appt)
    {
        try
        {
            var result = await _service.Create(new Appointment(appt));
            return StatusCode(201, result);
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }

}
