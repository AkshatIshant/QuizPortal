using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionGroupMicroserviceAPI.Models.Domain;

namespace QuestionGroupMicroserviceAPI.Tests.MockData
{
    public class QuestionGroupMockData
    {
        public static List<QuestionGroup> GetQuestionGroups()
        {
            var questionGroups = new List<QuestionGroup>()
            {
                new QuestionGroup() { Id = 1, Title=" C-Sharp ",QuizTitle = "Quiz on C++",TimeCreated=DateTime.Now,TimeUpdated=DateTime.Now },
                new QuestionGroup() { Id = 2, Title=" Html ",QuizTitle = "Quiz on HTML",TimeCreated=DateTime.Now,TimeUpdated=DateTime.Now },
                new QuestionGroup() { Id = 3, Title=" CSS ",QuizTitle = "Quiz on Angular",TimeCreated=DateTime.Now,TimeUpdated=DateTime.Now },
            };

            return questionGroups;
        }
        public static List<QuestionGroup> EmptyQuestionGroupsList()
        {
            return null;
        }
        public static QuestionGroup GetQuestionGroup()
        {
            var questionGroup = new QuestionGroup()
            {
                //Id = 1,
                Title = " C-Sharp ",
                QuizTitle = "quiz on c-sharp",
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now
            };

            return questionGroup;

        }
        public static QuestionGroup EmptyQuestionGroup()
        {
            return null;
        }
    } 
}
