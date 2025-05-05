namespace MovieLib.Core.Entities;

public class Review
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string ReviewerName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    // Navigation property for the one-to-many relationship
    public Movie Movie { get; set; } = null!;
}