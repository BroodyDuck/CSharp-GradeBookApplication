using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            base.CalculateStudentStatistics(name);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override double GetGPA(char letterGrade, StudentType studentType)
        {
            return base.GetGPA(letterGrade, studentType);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var min = Students.OrderBy(s => s.AverageGrade).FirstOrDefault().AverageGrade;
            var max = Students.OrderByDescending(s => s.AverageGrade).FirstOrDefault().AverageGrade;
            var perc = (averageGrade - min) / ((max - min) / 100);
            
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            if (perc > 80)
            {
                return 'A';
            }
            else if (perc < 80 && perc > 60)
            {
                return 'B';
            }
            else if (perc < 60 && perc > 40)
            {
                return 'C';
            }
            else if (perc < 40 && perc > 20)
            {
                return 'D';
            }
            return 'F';
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
