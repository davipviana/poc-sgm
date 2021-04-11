using System;

namespace SASCi.Services
{
    public class MedicalExamService : IMedicalExamService
    {
        public string GetExamResult(string s)
        {
            Random r = new Random();

            return $"{r.Next(0, 100)}";
        }
    }
}