namespace MovieLib.Core.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
    
    // Navigation property for the one-to-many relationship
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}