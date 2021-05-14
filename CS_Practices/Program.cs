using System;

namespace CS_Practices
{
    class Program
    {
        private static Enrollee __enrollee;
        private static Student __student;
        private static Extrabudgetary __extraBudgetary;
        private static Budgetary __budgetary;
        static void Main(string[] args)
        {
            
            // Enrollee enrollee = new Student(); //Это правильно?
            // enrollee.AutoFillingUserAcc();
            
            Console.WriteLine("ENROLEE INF\n---------------------------------------------------------------");
            __enrollee = new Enrollee();
            __enrollee.AutoFillingUserAcc();
            __enrollee.GetInfo();
            Console.WriteLine("STUDENT INF\n---------------------------------------------------------------");
            __student = __enrollee.Enrollment(false);
            __student.GetInfo();
            Console.WriteLine("STUDENT EB INF\n---------------------------------------------------------------");
            if (__student.IsBudgetary)
            {
                __budgetary = __student.ConvertToBudgetary<Budgetary>(__student);
                __budgetary.GetInfo();
                __budgetary.StartSession();
                __budgetary.GetSeesionResult();
                
                __budgetary.RetakeDiscipline();
                __budgetary.GetSeesionResult();
                __budgetary.RaiseSemester(true);
            }
            else
            {
                __extraBudgetary = __student.ConvertToExtraB<Extrabudgetary>(__student);
                __extraBudgetary.GetInfo();
                __extraBudgetary.StartSession();
                __extraBudgetary.GetSeesionResult();
            
                __extraBudgetary.RetakeDiscipline();
                __extraBudgetary.GetSeesionResult();
                __extraBudgetary.RaiseSemester(true);
            }
            //__extraBudgetary.GetInfo();
            // Console.WriteLine("STUDENT B INF\n---------------------------------------------------------------");
            // __budgetary = __student.ConvertToBudgetary<Budgetary>(__student);
            // __budgetary.GetInfo();
            // __budgetary.StartSession();
            // __budgetary.GetSeesionResult();
            //
            // __budgetary.RetakeDiscipline();
            // __budgetary.GetSeesionResult();
            // __budgetary.RaiseSemester(true);
            
            
            //Extrabudgetary extrabudgetarySt = student;

        }
    }
}