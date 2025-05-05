using System;
using System.Collections.Generic;

namespace MovieLib.Core.DTOs;

public class MovieWithReviewsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
    public IEnumerable<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
}
