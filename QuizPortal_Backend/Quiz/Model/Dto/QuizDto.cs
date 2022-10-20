
using QuizAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Dto
{
    public class QuizDto
    {
        
        public int Id { get; set; }
        [Required]
        public string QuizTitle { get; set; }
        [Required]
        public string Description { get; set; }
       
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
