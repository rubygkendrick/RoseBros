

namespace RoseBros.Models.DTOs;

public class RoseDTO
{

    public int Id { get; set; }

    public string Name { get; set; }

    public int ColorId { get; set; }
    public ColorDTO Color {get; set;}

    public int HabitId { get; set; }
    public HabitDTO Habit {get; set;}
   
    public string Description { get; set; }

    public string Image { get; set; }

    public decimal PricePerUnit { get; set; }

    public bool OutOfStock {get; set;}

}
