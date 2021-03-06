using DrivingLicenseExam.Core.DTO;
using DrivingLicenseExam.Core.Services;
using DrivingLicenseExam.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DrivingLicenseExam.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _questionService.GetAllQuestionsBasicInfoAsync());
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> AddNewQuestion([FromBody] QuestionCreationRequestDto dto)
    {
        try
        {
            await _questionService.AddNewQuestionAsync(dto);
        }
        catch (EntityNotFoundException e)
        {
            return BadRequest();
        }
        return NoContent();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateExistingQuestion([FromBody] QuestionUpdateRequestDto dto)
    {
        try
        {
            await _questionService.UpdateExistingQuestionAsync(dto);
        }
        catch (EntityNotFoundException e)
        {
            return BadRequest();
        }
        return NoContent();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteExistingQuestionById([FromQuery] int id)
    {
        try
        {
            await _questionService.DeleteExistingQuestionByIdAsync(id);
        }
        catch (EntityNotFoundException e)
        {
            return BadRequest();
        }
        return NoContent();
    }
}