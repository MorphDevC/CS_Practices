using System;
using System.Collections.Generic;

namespace Practice_3
{
    public class Enrollee:Person
    {
        public Enrollee():this(new EducationType())
        {
            
        }
        public Enrollee(EducationType educationType):this(educationType,0)
        {
            
        }
        public Enrollee(EducationType educationType,int finalChosenVectorEd):this(educationType,finalChosenVectorEd,"","","")
        {
        }
        public Enrollee(EducationType educationType,int finalChosenVectorEd,string name, string secondName, string surname):this(educationType,finalChosenVectorEd,"","","",0)
        {
        }
        public Enrollee(EducationType educationType,int finalChosenVectorEd,string name, string secondName, string surname,int score)
            :base(name,secondName,surname)
        {
            _educationType = educationType;
            FinalChosenVectorEd = finalChosenVectorEd;
            EntranceScores = score;
        }


        private EducationType _educationType = new EducationType();
        private int _entranceScores;
        private List<int> _chosenVectorEducations = new List<int>();
        private int _finalChosenVectorEd = 0;
        
        //------------------
        public string getEducation(int index)
        {
            if (index<=_educationType._vectorEducationCode.Count)
            {
                return $"{_educationType._vectorEducationCode[index]} - {_educationType._vectorEducationName[index]}";
            }
            else
            {
                return "Not existing education";
            }
        }

        public void GetEducations()
        {
            if (_educationType._vectorEducationCode.Count.Equals(_educationType._vectorEducationName.Count))
            {
                Console.WriteLine("Код направления - Наименование/ Свободных бюджетных мест");
                for (int i = 0; i < _educationType._vectorEducationCode.Count; i++)
                {
                    Console.WriteLine($"{i+1}) {_educationType._vectorEducationCode[i]} - {_educationType._vectorEducationName[i]}");
                }
            }
            else
            {
                // Do something
            }
        }
        public void GetChosenEducations()
        {
            foreach (var index in ChosenVectorEducations)
            {
                Console.WriteLine($"{_educationType._vectorEducationCode[index-1]} - {_educationType._vectorEducationName[index-1]}");   
            }
        }
        
        public bool isAlreadyChosen(int indexExisting)
        {
            foreach (var index in ChosenVectorEducations)
            {
                if (_educationType._vectorEducationCode[index]
                    .Equals(_educationType._vectorEducationCode[indexExisting]))
                {
                    return true;
                }
            }
            return false;
        }
       
        //-------------------
        public int EntranceScores
        {
            get => _entranceScores;
            set => _entranceScores = value;
        }

        public List<int> ChosenVectorEducations
        {
            get => _chosenVectorEducations;
            set => _chosenVectorEducations = value;
        }

        public int EducationCounts
        {
            get => _educationType._vectorEducationCode.Count;
        }

        public int FinalChosenVectorEd
        {
            get => _finalChosenVectorEd;
            set => _finalChosenVectorEd = value;
        }
    }
    public static class EnroleeExtentions
    {
        public static void FillingUserAcc(this Enrollee enrollee)
        {
            Console.WriteLine("Enter personal date FIO");
            string[] tempFIO = Console.ReadLine().Split(' ');
            enrollee.Surname = tempFIO[0];
            enrollee.Name = tempFIO[1];
            enrollee.SecondName = tempFIO[2];
            
            Console.WriteLine("Enter entrance score: ");
            enrollee.EntranceScores = Convert.ToInt16(Console.ReadLine());
            
            Console.WriteLine("Choose education vectors not more than 4 which you are intersted");
            enrollee.GetEducations();
            Console.WriteLine("Enter \"0\" to escape of choosing");
            for (int i = 0; i < 4; i++)
            {
                int tempInt = Convert.ToInt32(Console.ReadLine());
                if (tempInt == 0)
                {
                    break;
                }
                else if(tempInt<=enrollee.EducationCounts && !enrollee.isAlreadyChosen(tempInt))
                {
                    enrollee.ChosenVectorEducations.Add(tempInt);
                }
                else
                {
                    Console.WriteLine("There is does not exist that type of education vector or you are trying to choose previously chosen vector" +
                                      ", please, try once again");
                    i--;
                }
            }
        }
        public static void AutoFillingUserAcc(this Enrollee enrollee)
        {
            enrollee.Surname = "Pie";
            enrollee.Name = "Alex";
            enrollee.SecondName = "Alexandrovich";
            
            Console.WriteLine("Enter entrance score - 228");
            enrollee.EntranceScores = 228;
            
            Console.WriteLine("Education vectors exist");
            enrollee.GetEducations();

            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                int tempInt = rnd.Next(1, 6);
                if(tempInt<=enrollee.EducationCounts && !enrollee.isAlreadyChosen(tempInt))
                {
                    Console.WriteLine($"Random vector education: {enrollee.getEducation(tempInt)}");
                    enrollee.ChosenVectorEducations.Add(tempInt);
                }
                else
                {
                    Console.WriteLine("Random value already exist in chosen education vectors");
                    i--;
                }
            }

            enrollee.FinalChosenVectorEd = rnd.Next(0, enrollee.ChosenVectorEducations.Count);
        }
        
        public static void GetEnrolleeInf(this Enrollee enrollee)
        {
            Console.WriteLine($"Surname: {enrollee.Surname}\n" +
                              $"First name: {enrollee.Name}\n" +
                              $"Second name: {enrollee.SecondName}\n" +
                              $"Entrance score: {enrollee.EntranceScores}\n" +
                              $"Chosen education vectors:");
            enrollee.GetChosenEducations();
            Console.WriteLine($"Final chosen education vector: {enrollee.getEducation(enrollee.FinalChosenVectorEd)}");
        }
        public static Student Enrollment(this Enrollee enrollee, bool isPassed)
        {
            Student student = (Student) enrollee;
            student.IsBudgetary = isPassed;
            student.GeneratePersonalSC_RB(student.FinalChosenVectorEd);
            if (isPassed)
            {
                Console.WriteLine("Enrollee was enrollment for  budgetary place");
            }
            else
            {
                Console.WriteLine("Enrollee was enrollment for  extra budgetary place");
            }
            return student;
            //return (Student) enrollee; //почему это тоже работает, если бы не было "return student;"?
        }
    }

    public class EducationType
    {
        public List<string> _vectorEducationCode = new List<string>()
        {
            "09.03.02",
            "09.03.03",
            "01.03.02",
            "01.03.04",
            "02.02.02",
            "03.03.03"
        };
        public List<string> _vectorEducationName = new List<string>()
        {
            "Информационные системы и технологии",
            "Прикладная информатика",
            "Прикладная математика и информатика",
            "Прикладная математика",
            "Вымышленная программа 1",
            "Лучшая Вымышленная программа 2"
        };

        public static List<string> VectorEducationLetters = new List<string>()
        {
            "CT",
            "PI",
            "MI",
            "PM",
            "VP",
            "BV"
        };

        

        // 1-1; 2-2; 3-3 ...
    }
}