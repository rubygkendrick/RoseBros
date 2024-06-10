using System.ComponentModel.DataAnnotations;
namespace RoseBros.Models;

public class Color
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name {get; set;}

}