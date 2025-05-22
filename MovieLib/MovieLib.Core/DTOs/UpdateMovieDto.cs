using System;

namespace MovieLib.Core.DTOs;

public class UpdateMovieDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string? Director { get; set; }
} 