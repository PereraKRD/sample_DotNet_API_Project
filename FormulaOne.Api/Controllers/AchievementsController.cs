using AutoMapper;
using FormulaOne.DataSerivce.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Requests;
using FormulaOne.Entities.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class AchievementsController : BaseController
{
    public AchievementsController(
        IUnitofWork unitofWork, IMapper mapper) : base(unitofWork, mapper)
    {

    }
    
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetAchievementByDriverId(Guid driverId)
    {
        var result = await _unitofWork.Achievements.GetAchievementByDriverId(driverId);
        
        if(result == null) 
            return NotFound();
        
        var response = _mapper.Map<DriverAchievementResponse>(result);
        return Ok(response);
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateAchievement([FromBody] CreateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = _mapper.Map<Achievement>(achievement);
        
        await _unitofWork.Achievements.Add(result);
        await _unitofWork.CompleteAsync();
        
        return CreatedAtAction(nameof(GetAchievementByDriverId), new {driverId = result.DriverId}, result);
    }
    
    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = _mapper.Map<Achievement>(achievement);
        
        await _unitofWork.Achievements.Update(result);
        await _unitofWork.CompleteAsync();
        
        return NoContent();
    }
}

