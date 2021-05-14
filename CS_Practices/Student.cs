using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CS_Practices
{
    public class Student:Enrollee
    {
    #region ctors
        public Student()
        {
            
        }
        public Student(Enrollee enrollee,bool isPassed)
            :this(isPassed,enrollee.Name,enrollee.SecondName,enrollee.Surname,enrollee.EntranceScores,enrollee.FinalChosenVectorEdIndex)
        {
           
        }
        public Student(Student student,bool isPassed)
            :this(isPassed,student.Name,student.SecondName,student.Surname,student.EntranceScores,student.FinalChosenVectorEdIndex)
        {
           
        }
        public Student(bool isPassed,string name, string secondName, string surname, int entranceScore,int finalChosenVectorEd)
            :base(name,secondName,surname,entranceScore,finalChosenVectorEd)
        {
            IsBudgetary = isPassed;
            __studentStartedPack = new StudentStartedPack<Student>(this);
        }
    #endregion

    #region private fields
        private int _semester = 1;
        private bool _isBudgetary;

        private StudentStartedPack<Student> __studentStartedPack;
    #endregion

    #region public methods
        public T ConvertToExtraB<T>(Student student)where T:Extrabudgetary
        {
            Extrabudgetary extrabudgetary = new Extrabudgetary(student);
            return (T) Convert.ChangeType(extrabudgetary,typeof(T));
        }
        public T ConvertToBudgetary<T>(Student student)where T:Budgetary
        {
            Budgetary budgetary = new Budgetary(student);
            return (T) Convert.ChangeType(budgetary,typeof(T));
        }

        public virtual void RaiseSemester(bool isRasing) // switcherSemester with new disciplines
        {
            if (!isRasing)
                return;
            else
            {
                if(!HasRetakes ||(HasRetakes && __studentStartedPack.NotPassedDisciplinesIndex.Count<=2))
                {
                    Console.WriteLine("Semester has been raised");
                    Semester++;
                }
                else
                    Console.WriteLine("Can not raise semester cuz of your retakes counts");
            }
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Record book: {__studentStartedPack.RB_ID}\n" +
                              $"Student card: {__studentStartedPack.SC_ID}\n" +
                              $"Course: {Course}");
            if(this.IsBudgetary)
                Console.WriteLine($"Student {this.Surname}{this.Name} - {this.StudentCard} is budgetary");
            else
                Console.WriteLine($"Student {this.Surname}{this.Name} - {this.StudentCard} is extrabudgetary");
        }

        public void StartSession()
        {
            __studentStartedPack.GetSemesterSessionDisciplines(EducationTypePr,this);
            
            __studentStartedPack.PassDisciplinesRND(false);
            Console.WriteLine("MAIN SESSION HAS BEEN FINISHED");
        }
        public void RetakeDiscipline()
        {
            Console.WriteLine("Retaking disciplines is starting.");
            __studentStartedPack.PassDisciplinesRND(true);
        }
        public void GetSeesionResult()
        {
            __studentStartedPack.SessionResult(EducationTypePr,this);
        }
    #endregion
    
    #region public Properties
        
        public bool IsBudgetary
        {
            get => _isBudgetary;
            set
            {
                if (value)
                {
                    Console.WriteLine("Now you are on budgetary place education");
                }
                else
                {
                    Console.WriteLine("Now you are on extra budgetary place education");
                }

                _isBudgetary = value;
            }
        }
        
        public string StudentCard => __studentStartedPack.SC_ID;
        public string RecordBook => __studentStartedPack.SC_ID;

        public int Course
        {
            get
            {
                var tempFloat = (Convert.ToDouble(Semester) / 2) + 0.5f;
                return Convert.ToInt32(tempFloat);
            }
           
        }
        public int Semester
        {
            get => _semester;
            private set => _semester = value;
        }

        public bool HasRetakes
        {
            get
            {
                if (__studentStartedPack.NotPassedDisciplinesIndex.Count >= 1 )
                    return true;
                else
                    return false;
            }
        }

    #endregion
    }

    public class Extrabudgetary:Student
    {
        private string _contract;
        private int _semesterPayment;
        
        public Extrabudgetary(Student student):base(student,false)
        {
            this.Contract = "№123B3323"; // Some idea to normilize contract id
            this.SemesterPayment = 100000; // the same as upper
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Number of your contract is: {Contract}\n" +
                              $"Your payment for semester is: {SemesterPayment}");
            
        }
        public override void RaiseSemester(bool isRasing) // switcherSemester with new disciplines
        {
            //code here
            if(HasPaid)
                base.RaiseSemester(isRasing);
            else
                Console.WriteLine("Вы не залатили налог");
        }
        
        public int SemesterPayment
        {
            get => _semesterPayment;
            set => _semesterPayment = value;
        }
        public string Contract
        {
            get => _contract;
            set => _contract = value;
        }

        public bool HasPaid
        {
            get
            {
                Random rnd = new Random();
                if (rnd.Next(2) == 1)
                    return true;
                else
                    return false;
            }
        }
    }
    
    public class Budgetary:Student
    {
        public Budgetary(Student student):base(student,true)
        {
            Scholarship = 1000;
        }
        
        private int _scholarship;

        public int Scholarship
        {
            private get => _scholarship;
            set => _scholarship = value;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Your scholarship is: {GetScholarship}");
        }

        public override void RaiseSemester(bool isRasing) // switcherSemester with new disciplines
        {
            //code here
            base.RaiseSemester(isRasing);
        }

        public int GetScholarship
        {
            get => Scholarship;
        }
        
    }

    public class StudentStartedPack<T>:EducationType
    {
        #region CTORS
        
        public StudentStartedPack(Student student)
        {
            var tempListMax = Disciplines[student.FinalChosenVectorEdIndex].Count;
            for (int i = 0; i < tempListMax; i++)
            {
                SessionDisciplines.Add(false);
            }
            GeneratePersonalSC_RB(student.FinalChosenVectorEdIndex);
        }
        #endregion

        #region private fields
        
        private static int __nubmer = 0;
        private string _recordBook_ID = "RB";// RB
        private string _studentCard_ID = "SC";
        private List<int> _notPassedDisciplinesIndex = new List<int>(); 
        #endregion
        
        #region Public Methods
        
        public void GeneratePersonalSC_RB(int indexEdVector)
        {
            int years = DateTime.Today.Year;
            string EducationLetters = EducationType.VectorEducationLetters[indexEdVector]; // fix
            _recordBook_ID = _recordBook_ID + (years.ToString() + EducationLetters + __nubmer);
            _studentCard_ID = _studentCard_ID + (years.ToString() + EducationLetters + __nubmer);
        }
        public void GetSemesterSessionDisciplines(EducationType EducationTypePr,Student student)
        {
            Console.WriteLine("\nDisciplines for exam:");
            foreach (var discName in EducationTypePr.Disciplines[student.FinalChosenVectorEdIndex])
            {
                Console.WriteLine(discName);
            }
        }
        #endregion
        
        #region Public Properties
        
        public List<bool> SessionDisciplines = new List<bool>();
        public string RB_ID => _recordBook_ID;
        public string SC_ID => _studentCard_ID;

        public List<int> NotPassedDisciplinesIndex
        {
            get => _notPassedDisciplinesIndex;
            set => _notPassedDisciplinesIndex = value;
        }

        #endregion
    }
    
    public static class StudentExt
    {
        public static void GetStudentInf(this Student student)
        {
            Console.WriteLine(student.Name);
            Console.WriteLine(student.SecondName);
            Console.WriteLine(student.Surname);
            Console.WriteLine(student.FinalChosenVectorEdIndex);
            Console.WriteLine(student.EntranceScores);
        }
    }

    public static class StudentStartedPackExt
    {
        public static void PassDisciplinesRND(this StudentStartedPack<Student> startedPack,bool isRetake) //передвать ссылку или взять от сюда?
        {
            Random rnd = new Random(); //rnd.next()
            if (!isRetake)
            {
                int lengt = startedPack.SessionDisciplines.Count;
                for (int i = 0; i < lengt; i++)
                {
                    if (rnd.Next(2) == 0)
                    {
                        startedPack.SessionDisciplines[i] = false;
                        startedPack.NotPassedDisciplinesIndex.Add(i);
                    }
                    else
                        startedPack.SessionDisciplines[i] = true;
                }
            }
            else
            {
                int tempRetakedDisc = 0;
                int tempLenght = startedPack.NotPassedDisciplinesIndex.Count;
                for (int i = 0; i < tempLenght; i++)
                {
                    if (rnd.Next(2) == 1)
                    {
                        startedPack.SessionDisciplines[startedPack.NotPassedDisciplinesIndex[i]] = true; //true here
                        startedPack.NotPassedDisciplinesIndex.RemoveAt(i);
                        i--;
                        tempLenght--;
                        tempRetakedDisc++;
                    }
                }
                Console.WriteLine($"ЗА ПЕРЕСДАЧУ СДАНО: {tempRetakedDisc} дисциплины");
            }
        }
        public static void SessionResult(this StudentStartedPack<Student> startedPack,EducationType EducationTypePr,Student student) //ext
        {
            Console.WriteLine("\nResult of session:");
            int lenght = startedPack.SessionDisciplines.Count;
            int studentChose = student.FinalChosenVectorEdIndex;
            for (int i = 0; i < lenght; i++)
            {
                Console.Write($"{EducationTypePr.Disciplines[studentChose][i]} ");
                if(startedPack.SessionDisciplines[i])
                    Console.WriteLine("сдана");
                else
                {
                    Console.WriteLine("не сдана");
                }
            }
        }
        public static bool GetNotPassedDisciplines(this StudentStartedPack<Student> startedPack)
        {
            if (startedPack.NotPassedDisciplinesIndex.Count >= 1)
            {
                foreach (var discipline in startedPack.NotPassedDisciplinesIndex)
                {
                    Console.WriteLine((discipline+1));
                }
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
    }
}