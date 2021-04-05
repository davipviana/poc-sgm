using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using SASCi.Models;

namespace SASCi.Services
{
    public class MedicalExamService : IMedicalExamService
    {
        public string GetExamResult(string s)
        {
            Random r = new Random();

            return $"{s} - {r.Next(0, 100)}%";
        }
    }
}