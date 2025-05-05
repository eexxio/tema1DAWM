using System;

namespace MovieLib.Core.DTOs;

public class ReviewDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string ReviewerName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
