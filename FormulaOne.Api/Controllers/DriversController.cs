using AutoMapper;
using FormulaOne.Api.Services.Interfaces;
using FormulaOne.DataSerivce.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Requests;
using FormulaOne.Entities.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController : BaseController
{
    private readonly IDriverNotificationPublisherService _driverNotificationPublisherService;
    public DriversController(
        IUnitofWork unitofWork, 
        IMapper mapper, 
        IDriverNotificationPublisherService driverNotificationPublisherService) : base(unitofWork, mapper)
    {
        _driverNotificationPublisherService = driverNotificationPublisherService;
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverByDriverId(Guid driverId)
    {
        var driver = await _unitofWork.Drivers.GetById(driverId);
        
        if(driver == null) 
            return NotFound();
        
        var response = _mapper.Map<GetDriverResponse>(driver);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var drivers = await _unitofWork.Drivers.All();
        var response = _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
        return Ok(response);
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateDriver([FromBody] CreateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = _mapper.Map<Driver>(driver);
        
        await _unitofWork.Drivers.Add(result);
        await _unitofWork.CompleteAsync();
        
        await _driverNotificationPublisherService.SentNotification(result.Id, result.FirstName + " " + result.LastName);
        
        return CreatedAtAction(nameof(GetDriverByDriverId), new {driverId = result.Id}, result);
    }
    
    [HttpPut("")]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var result = _mapper.Map<Driver>(driver);
        
        await _unitofWork.Drivers.Update(result);
        await _unitofWork.CompleteAsync();
        
        return NoContent();
    }
    
    [HttpDelete("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        await _unitofWork.Drivers.Delete(driverId);
        await _unitofWork.CompleteAsync();
        
        return NoContent();
    }
}