using System.ComponentModel.DataAnnotations;

namespace KP.FunOA.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}