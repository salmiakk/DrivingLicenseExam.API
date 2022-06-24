using DrivingLicenseExam.Core.DTO;
using DrivingLicenseExam.Core.Services;
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
        await _questionService.AddNewQuestionAsync(dto);
        return NoContent();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateExistingQuestion([FromBody] QuestionUpdateRequestDto dto)
    {
        await _questionService.UpdateExistingQuestionAsync(dto);
        return NoContent();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteExistingQuestionById([FromQuery] int id)
    {
        Console.Write("Hi! Id value is: " + id);
        await _questionService.DeleteExistingQuestionByIdAsync(id);
        return NoContent();
    }
}