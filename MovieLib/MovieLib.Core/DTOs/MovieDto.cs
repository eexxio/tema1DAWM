using System;

namespace MovieLib.Core.DTOs;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
}
