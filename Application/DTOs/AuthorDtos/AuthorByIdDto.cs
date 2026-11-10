namespace Application.DTOs.AuthorDtos;

public class AuthorByIdDto
{
    public int Id { get; set; }
    public string Fullname { get; set; } = null!;
    public string Country { get; set; } = null!;
    public int Birthdate { get; set; }
}
