using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    public abstract class Challenge
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

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Испытание: {name} по {subj}, дата: {date}");
        }

        public abstract string GetChallengeType();
    }

    public class Exam : Challenge
    {
        private int pointsToPass;
        private string acceptKey;

        public Exam(string subj = "Любой", string name = "Без названия", string date = "00.00.00",
                   int pointsToPass = 0, string acceptKey = "none") : base(subj, name, date)
        {
            this.pointsToPass = pointsToPass;
            this.acceptKey = acceptKey;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Тип: Экзамен, Проходной балл: {pointsToPass}, Ключ доступа: {acceptKey}");
        }

        public override string GetChallengeType() => "Экзамен";

        public bool Pass(int points) => pointsToPass <= points;
    }

    public class EExam : Exam
    {
        private int pasportID;
        private string indx;

        public EExam(string subj = "Любой", string name = "Без названия", string date = "00.00.00",
                    int pointsToPass = 0, string acceptKey = "none",
                    int pasportID = 1234, string indx = "xxxx-xxxx")
            : base(subj, name, date, pointsToPass, acceptKey)
        {
            this.pasportID = pasportID;
            this.indx = indx;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Выпускной экзамен: ID паспорта: {pasportID}, Индекс: {indx}");
        }

        public override string GetChallengeType() => "Выпускной экзамен";
    }

    public class Test : Challenge
    {
        public int maxPoints;

        public Test(string subj = "Любой", string name = "Без названия", string date = "00.00.00",
                   int maxPoints = 20) : base(subj, name, date)
        {
            this.maxPoints = maxPoints;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Тест: {name}, Макс. баллов: {maxPoints}, Предмет: {subj}");
        }

        public override string GetChallengeType() => "Тест";

        public double CalculateScore(int earnedPoints) => (double)earnedPoints / maxPoints * 100;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Exam ex1 = new Exam("Математика", "экзамен", "20.12.2024", 60, "MATH2024");
            EExam ex2 = new EExam("Физика", "ЕГЭ", "15.12.2024", 70, "PHYS2024", 9876, "TEST-1234");
            Test t1 = new Test("История", "Контрольная работа", "10.12.2024", 50);
            ex1.DisplayInfo();
            ex2.DisplayInfo();
            t1.DisplayInfo();
        }
    }
}