using System.ComponentModel.DataAnnotations;

namespace RoseBros.Models;

public class Rose
{

    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    [Required]
    public int ColorId { get; set; }

    public Color Color { get; set; }

    [Required]
    public int HabitId { get; set; }
    public Habit Habit { get; set; }

    [Required]
    public string Description { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public decimal PricePerUnit { get; set; }

}
