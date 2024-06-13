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
        return Ok(_dbContext.Roses.Include(r => r.Habit).Include(r => r.Color)
            .Select(r => new RoseDTO
            {
                Id = r.Id,
                Name = r.Name,
                ColorId = r.ColorId,
                Color = new ColorDTO
                {
                    Id = r.Color.Id,
                    Name = r.Color.Name
                },
                HabitId = r.HabitId,
                Habit = new HabitDTO
                {
                    Id = r.Habit.Id,
                    Name = r.Habit.Name
                },
                Description = r.Description,
                Image = r.Image,
                PricePerUnit = r.PricePerUnit
            }).ToList());
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Rose rose = _dbContext.Roses
        .Include(r => r.Habit)
        .Include(r => r.Color)
        .SingleOrDefault(r => r.Id == id);

        if (rose == null)
        {
            return NotFound("This Rose does not exist in the system");
        }

        return Ok(new RoseDTO
        {
            Id = rose.Id,
            Name = rose.Name,
            ColorId = rose.ColorId,
            HabitId = rose.HabitId,
            Habit = new HabitDTO
            {
                Id = rose.Habit.Id,
                Name = rose.Habit.Name
            },
            Color = new ColorDTO
            {
                Id = rose.Color.Id,
                Name = rose.Color.Name
            },
            Description = rose.Description,
            Image = rose.Image,
            PricePerUnit = rose.PricePerUnit
        });
    }

    [HttpPost("add")]
    //[Authorize(Roles = "Admin")]
    public IActionResult AddRose(Rose newRose)
    {

        if (newRose == null)
        {
            return BadRequest("The rose you are trying to add is null or has incomplete information");
        }

        var existingRose = _dbContext.Roses.FirstOrDefault(r => r.Name == newRose.Name);


        var color = _dbContext.Colors.Find(newRose.ColorId);
        var habit = _dbContext.Habits.Find(newRose.HabitId);

        if (color == null || habit == null)
        {
            return BadRequest("Invalid ColorId or HabitId");
        }

        if (existingRose == null)
        {
            var roseToAdd = new Rose
            {
                Name = newRose.Name,
                ColorId = newRose.ColorId,
                Color = color,
                HabitId = newRose.HabitId,
                Habit = habit,
                Description = newRose.Description,
                Image = newRose.Image,
                PricePerUnit = newRose.PricePerUnit,
            };

            _dbContext.Roses.Add(roseToAdd);
            _dbContext.SaveChanges();

            return Ok(roseToAdd);
        }
        else
        {
            return BadRequest("A Rose with this name already exists in the database");
        }

    }


}