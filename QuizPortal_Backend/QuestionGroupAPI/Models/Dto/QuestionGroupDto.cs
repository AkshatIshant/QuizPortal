using QuestionGroupMicroserviceAPI.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuestionGroupMicroserviceAPI.Models.Dto
{
    public class QuestionGroupDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
        public string? QuizTitle { get; set; }
    }
}
