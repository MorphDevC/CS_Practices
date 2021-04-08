using System;
using System.Linq;

namespace CS_Practices
{
    public class Student:Enrollee
    {
        public Student()
        {
            
        }
        public Student(EducationType educationType,int finalChosenVectorEd,string name, string secondName, string surname)
            :base(educationType,finalChosenVectorEd,name,secondName,surname)
        {
            for (int i = 0; i < _numberStudent.Length; i++)
            {
                _numberStudent[i] = 0;
            }
        }
        
        
        private string _recordBook = "RB";// RB
        private string _studentCard = "SC";// SC
        private bool _isBudgetary;
        private int[] _lettersID = new int[EducationType.VectorEducationLetters.Count];
        private int[] _numberStudent = new int[EducationType.VectorEducationLetters.Count];
        private Extrabudgetary _extrabudgetary;
        private Budgetary _budgetary;
        
        public void GeneratePersonalSC_RB(int indexEdVector)
        {
            int years = DateTime.Today.Year;
            string EducationLetters = EducationType.VectorEducationLetters[indexEdVector];
            int numberStudent = _lettersID[indexEdVector]++;
            _recordBook = RecordBook + (years.ToString() + EducationLetters + numberStudent.ToString());
            _studentCard = StudentCard + (years.ToString() + EducationLetters + numberStudent.ToString());
        }

        public void GetPlaceInfo()
        {
            if (!IsBudgetary)
            {
                Console.WriteLine($"Number of your contract is: {_extrabudgetary.Contract}\n" +
                                  $"Your payment for semester is: {_extrabudgetary.SemesterPayment}");
            }
            else
            {
                Console.WriteLine($"Your scholarship is: {_budgetary.Scholarship}");
            }
        }

        public bool IsBudgetary
        {
            get => _isBudgetary;
            set
            {
                if (value)
                {
                    Console.WriteLine("Now you are on budgetary place education");
                    _budgetary = new Budgetary();
                    _budgetary.Scholarship = 1000;
                }
                else
                {
                    Console.WriteLine("Now you are on extra budgetary place education");
                    _extrabudgetary = new Extrabudgetary();
                    _extrabudgetary.Contract = "123";
                    _extrabudgetary.SemesterPayment = "1000 $";
                }

                _isBudgetary = value;
            }
        }
        public string RecordBook => _recordBook;
        public string StudentCard => _studentCard;
    }

    public static class ExtStudent
    {
        
    }

    public class Extrabudgetary:Student
    {
        private string _contract;
        private string _semesterPayment;

       
        
        public string SemesterPayment
        {
            get => _semesterPayment;
            set => _semesterPayment = value;
        }

        public string Contract
        {
            get => _contract;
            set => _contract = value;
        }
    }
    
    public class Budgetary:Student
    {
        private int _scholarship;

        public int Scholarship
        {
            get => _scholarship;
            set => _scholarship = value;
        }
    }
}