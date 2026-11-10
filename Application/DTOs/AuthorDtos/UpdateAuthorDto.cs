namespace Application.DTOs.AuthorDtos;

public class UpdateAuthorDto
{
    public string Fullname { get; set; } = null!;
    public string Country { get; set; } = null!;
    public int Birthdate { get; set; }
}
