
using QuizAPI.Models.Domain;

namespace QuizAPI.Tests.MockData
{
    public static class QuizMockData
    {
        public static List<Quiz> GetQuizs()
        {
            var quizs = new List<Quiz>()
            {
                    new(){
                    Id=1,QuizTitle="Quiz 1",Description="xyz", StartTime= new DateTime (2015,09,12,02,32,00,00) ,EndTime=new DateTime (2015,09,12,03,00,00,00) },
                    new(){
                    Id=2,QuizTitle="Quiz 2",Description="abc", StartTime = new DateTime (2015,09,12,03,32,00,00) ,EndTime = new DateTime (2015,09,12,03,00,00,00) },
                    new(){
                    Id=3,QuizTitle="Quiz 3",Description ="pqr",StartTime = new DateTime (2015,09,12,04,32,00,00),EndTime =  new DateTime (2015,09,12,05,00,00,00)}
            };
            return quizs;
        }
        public static List<Quiz> EmptyQuizList()
        {
            return null;
        }
        public static Quiz GetQuizByIdAsync()
        {
            var quiz = new Quiz()
            {

                // Id = 1,
                QuizTitle = "Quiz 1",
                Description = "xyz",
               
                StartTime = new DateTime(2015, 09, 12, 02, 32, 00, 00),
                EndTime = new DateTime(2015, 09, 12, 03, 00, 00, 00)
            };
            return quiz;
        }
        public static Quiz EmptyQuiz()
        {
            return null;
        }


    }
}