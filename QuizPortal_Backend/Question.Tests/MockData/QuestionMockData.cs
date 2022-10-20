using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionMicroserviceAPI.Data;
using QuestionMicroserviceAPI.Models.Domain;

namespace QuestionAPI.Tests.MockData
{
    public static class QuestionMockData
    {
        public static List<Question> GetQuestions()
        {
            var questions = new List<Question>()
            {
                new Question() { Id = 1, QuestionText="what is 1+1=? ",Option1="3",Option2="4",Option3="2",Option4="5",CorrectAnswer="2",DifficultyLevel="1",QuestionGroupTitle="C++",TimeCreated=new DateTime(2022,10,12,2,30,40),TimeUpdated= new DateTime(2022,10,12,2,30,40) },
                new Question() { Id = 2, QuestionText="Sun Rises in the? ",Option1="East",Option2="West",Option3="North",Option4="South",CorrectAnswer="East",DifficultyLevel="2",QuestionGroupTitle="HTML",TimeCreated=new DateTime(2022,10,12,2,30,40),TimeUpdated=new DateTime(2022,10,12,2,30,40)},
                new Question() { Id = 3, QuestionText="Golkonda Fort is in? ",Option1="Delhi",Option2="Mumbai",Option3="Hyderabad",Option4="Chennai",CorrectAnswer="Hyderabad",DifficultyLevel="3",QuestionGroupTitle="Angular",TimeCreated=new DateTime(2022,10,12,2,30,40),TimeUpdated=new DateTime(2022,10,12,2,30,40) }
            };

            return questions;
        }
        public static List<Question> EmptyQuestionsList()
        {
            return new List<Question>();
        }

        public static Question GetQuestion()
        {
            var question = new Question()
            {
                //Id = 1,
                QuestionText = "what is 1+1=? ",
                Option1 = "3",
                Option2 = "4",
                Option3 = "2",
                Option4 = "5",
                CorrectAnswer = "2",
                DifficultyLevel = "1",
                QuestionGroupTitle = "H++",
                TimeCreated = new DateTime(2022, 10, 12, 2, 30, 40),
                TimeUpdated = new DateTime(2022, 10, 12, 2, 30, 40)
            };

            return question;

        }
        public static Question EmptyQuestion()
        {
            return null;
        }

    }   
}
