using ResultMicroserviceAPI.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortal.Tests.MockData
{
    public static class ResultMockData
    {
        public static List<Result> GetResults()
        {
            return new List<Result>
            {
                new(){Id=1,MarksObtained=78,ExamDate=DateTime.Now},
                new(){Id=2,MarksObtained=45,ExamDate=DateTime.Now},
                new(){Id=3, MarksObtained = 68,ExamDate= DateTime.Now},
                new(){Id=4, MarksObtained = 78,ExamDate=DateTime.Now},
                new(){Id=5, MarksObtained = 38,ExamDate=DateTime.Now},
            };
        }

        public static List<Result> EmptyResultList()
        {
            return new List<Result>();
        }

        public static Result GetResultById()
        {
            var result = new Result()
            {
                Id =1, MarksObtained = 78, ExamDate = DateTime.Now,
            };
            return result;
        }

        public static Result EmptyResults()
        {
            return null;
        }

        public static Result AddResult()
        {
            var result = new Result()
            {
                
                MarksObtained = 78,
                ExamDate = DateTime.Now,
            };
            return result;
        }

       




    }
}
