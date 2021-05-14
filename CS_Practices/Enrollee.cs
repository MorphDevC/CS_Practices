using System;
using System.Collections.Generic;

namespace CS_Practices
{
    public class Enrollee:Person
    {
        #region ctors
        public Enrollee():this("","","",0,0)
        {
            
        }
        public Enrollee(string name, string secondName, string surname,int entranceScores,int finalChosenVectorEd)
            :base(name,secondName,surname)
        {
            EntranceScores = entranceScores;
            FinalChosenVectorEdIndex = finalChosenVectorEd;
        }
        #endregion

        #region privateFields
        
        private EducationType _educationType = new EducationType();
        private int _entranceScores;
        private List<int> _chosenVectorEducations = new List<int>();
        private int _finalChosenVectorEd = 0;
        #endregion
        
        //------------------
        public string getEducation(int index)
        {
            if (index<=EducationTypePr._vectorEducationCode.Count)
            {
                return $"{EducationTypePr._vectorEducationCode[index]} - {EducationTypePr._vectorEducationName[index]}";
            }
            else
            {
                return "Not existing education";
            }
        }

        public void GetEducations()
        {
            if (EducationTypePr._vectorEducationCode.Count.Equals(EducationTypePr._vectorEducationName.Count))
            {
                Console.WriteLine("Код направления - Наименование/ Свободных бюджетных мест");
                for (int i = 0; i < EducationTypePr._vectorEducationCode.Count; i++)
                {
                    Console.WriteLine($"{i+1}) {EducationTypePr._vectorEducationCode[i]} - {EducationTypePr._vectorEducationName[i]}");
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
                Console.WriteLine($"{EducationTypePr._vectorEducationCode[index-1]} - {EducationTypePr._vectorEducationName[index-1]}");   
            }
        }
        
        public bool isEducationChosen(int indexExisting)
        {
            foreach (var index in ChosenVectorEducations)
            {
                if (EducationTypePr._vectorEducationCode[index]
                    .Equals(EducationTypePr._vectorEducationCode[indexExisting]))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Surname: {Surname}\n" +
                              $"First name: {Name}\n" +
                              $"Second name: {SecondName}\n" +
                              $"Entrance score: {EntranceScores}\n");
            
            Console.WriteLine($"Final chosen education vector: {getEducation(FinalChosenVectorEdIndex)}");
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
            get => EducationTypePr._vectorEducationCode.Count;
        }

        public int FinalChosenVectorEdIndex
        {
            get => _finalChosenVectorEd;
            set => _finalChosenVectorEd = value;
        }

        public EducationType EducationTypePr => _educationType;
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
                else if(tempInt<=enrollee.EducationCounts && !enrollee.isEducationChosen(tempInt))
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
                if(tempInt<=enrollee.EducationCounts && !enrollee.isEducationChosen(tempInt))
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

            enrollee.FinalChosenVectorEdIndex = rnd.Next(0, enrollee.ChosenVectorEducations.Count);
        }
        public static Student Enrollment(this Enrollee enrollee,bool isPassed)
        {
            Student student = new Student(enrollee,isPassed);
            return student;
        }
    }
}