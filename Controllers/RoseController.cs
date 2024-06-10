using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoseBros.Data;
using RoseBros.Models;
using RoseBros.Models.DTOs;


namespace RoseBros.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoseController : ControllerBase
{
    private RoseBrosDbContext _dbContext;

    public RoseController(RoseBrosDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Roses.Include(r => r.Habit)
            .Select(r => new RoseDTO
            {
                Id = r.Id,
                Name = r.Name,
                ColorId= r.ColorId,
                HabitId = r.HabitId,
                Habit =  new HabitDTO {
                    Id = r.Habit.Id,
                    Name = r.Habit.Name
                },
                Description = r.Description,
                Image = r.Image,
                PricePerUnit = r.PricePerUnit
            }).ToList());
    }

}