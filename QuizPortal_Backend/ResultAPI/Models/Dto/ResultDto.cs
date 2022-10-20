using ResultMicroserviceAPI.Model.Domain;

namespace ResultMicroserviceAPI.Model.Dto
{
    public class ResultDto
    {
        public int Id { get; set; }

        public int MarksObtained { get; set; }

        public DateTime ExamDate { get; set; }

        public string? QuizTitle { get; set; }

        public string? UserName { get; set; }
    }
}
