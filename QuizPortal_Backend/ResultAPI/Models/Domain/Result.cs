using System.ComponentModel.DataAnnotations;

namespace ResultMicroserviceAPI.Model.Domain
{
    public class Result
    {
        public int Id { get; set; }
        [Required]
        public int MarksObtained { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime ExamDate { get; set; }
      
        public string? QuizTitle { get; set; }
       
        public string? UserName { get; set; }
    }
}
