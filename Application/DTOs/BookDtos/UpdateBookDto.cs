namespace Application.DTOs.BookDtos;

public class UpdateBookDto
{
    public string Title { get; set; } = null!;
    public int CreateYear { get; set; }
    public decimal Price { get; set; }
}
