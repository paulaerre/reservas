using Microsoft.AspNetCore.Mvc;
using ReservasAPI.Models;
using ReservasAPI.Services;

namespace ReservasAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ServicesController : ControllerBase
{
    private readonly ILogger<ServicesController> _logger;
    private readonly IServiceService _service;
    public ServicesController(ILogger<ServicesController> logger, IServiceService serviceService)
    {
        _logger = logger;
        _service = serviceService;
    }

    /// <summary>
    /// 2. Get que devuelve todos los servicios disponibles.
    /// </summary>
    [HttpGet]
    [Route("/services")]
    public async Task<ActionResult<IEnumerable<Service>>> Get()
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

}
