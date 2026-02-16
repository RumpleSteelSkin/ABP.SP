using System.ComponentModel.DataAnnotations;

namespace ABP.SP.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}