namespace Application.DTOs.BookDtos;

public class CreateBookDto
{
    public string Title { get; set; } = null!;
    public int CreateYear { get; set; }
    public decimal Price { get; set; }
}
