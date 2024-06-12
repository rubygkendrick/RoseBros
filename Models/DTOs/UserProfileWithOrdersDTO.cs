
using Microsoft.AspNetCore.Identity;

namespace RoseBros.Models.DTOs;

public class UserProfileWithOrdersDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }

    public string UserName { get; set; }
    public List<string> Roles { get; set; }

    public List<Order>? Orders {get; set;}

}