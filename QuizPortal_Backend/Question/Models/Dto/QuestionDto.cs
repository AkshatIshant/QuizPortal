using System.ComponentModel.DataAnnotations;

namespace QuestionMicroserviceAPI.Models.Dto
{
    public class QuestionDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public string Option1 { get; set; }
        [Required]
        public string Option2 { get; set; }
        [Required]
        public string Option3 { get; set; }
        [Required]
        public string Option4 { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
        [Required]
        public string DifficultyLevel { get; set; }

        public string? QuestionGroupTitle { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
    }
}

