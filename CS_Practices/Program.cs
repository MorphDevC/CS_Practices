using System;

namespace CS_Practices
{
    class Program
    {
        static void Main(string[] args)
        {
            Enrollee enrollee = new Student(); //Это правильно?
            enrollee.AutoFillingUserAcc();
            //enrollee.FillingUserAcc();
            Console.WriteLine();
            enrollee.GetEnrolleeInf();
            Student student = enrollee.Enrollment(false);
            student.GetPlaceInfo();
            student.IsBudgetary = true;
            student.GetPlaceInfo();
        }
    }
}