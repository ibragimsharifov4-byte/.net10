namespace Application.DTOs.BookDtos;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int CreateYear { get; set; }
    public decimal Price { get; set; }
}
