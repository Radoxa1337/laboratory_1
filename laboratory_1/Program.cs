using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    public class Challenge
    {
        public string subj;
        public string name;
        public string date;
        public Challenge(string subj = "Любой", string name = "Без названия", string date = "00.00.00")
        {
            this.subj = subj;
            this.name = name;
            this.date = date;
        }
    }

    public class Exam : Challenge
    {
        private int pointsToPass;
        private string acceptKey;
        public Exam(string subj, string name, string date, int pointsToPass = 0, string acceptKey = "none") :
            base(subj, name, date)
        {
            this.pointsToPass = pointsToPass;
            this.acceptKey = acceptKey;
        }
        public bool Pass(int points)
        {
            if (pointsToPass <= points)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class EExam : Exam
    {
        private int pasportID;
        private string indx;
        public EExam(string subj, string name, string date, int pointsToPass, string acceptKey, int pasportID = 1234, string indx = "xxxx-xxxx")
            : base(subj, name, date, pointsToPass, acceptKey)
        { this.pasportID = pasportID; this.indx = indx; }
    }

    public class Test : Challenge
    {
        public int maxPoints;
        public Test(string subj, string name, string date, int maxPoints = 20)
            : base(subj, name, date)
        {
            this.maxPoints = maxPoints;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Exam ex = new Exam("русский", "тест на знание", "18.09.2025", 40, "Tim1");
            Console.WriteLine(ex.Pass(23));
        }
    }
}