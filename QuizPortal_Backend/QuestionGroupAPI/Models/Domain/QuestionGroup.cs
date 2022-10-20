using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionGroupMicroserviceAPI.Models.Domain
{
    public class QuestionGroup
    {
        [Key]
        public int Id { get; set; } 
        [Required]  
        public string Title { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }

        public string? QuizTitle { get; set; }

        //public List<Question> Questions { get; set; }
    }
}
