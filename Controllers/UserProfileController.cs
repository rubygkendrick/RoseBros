using System.Collections.Immutable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoseBros.Data;
using RoseBros.Models;
using RoseBros.Models.DTOs;


namespace RoseBros.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private RoseBrosDbContext _dbContext;

    public UserProfileController(RoseBrosDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        UserProfile user = _dbContext.UserProfiles.Include(up => up.Orders).ThenInclude(o => o.OrderRoses).ThenInclude(or => or.Rose)
        .SingleOrDefault(up => up.Id == id);

        if (user == null)
        {
            return NotFound("This user does not exist in the system");
        }

        List<Order> orders = _dbContext.Orders.Where(o => o.UserProfileId == id).ToList();

        return Ok(new UserProfileWithOrdersDTO
       {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Orders = orders
            });
    }

    

}