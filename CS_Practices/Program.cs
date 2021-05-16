using System;
using System.Collections.Generic;
using System.Drawing;

namespace CS_Practices
{
    class Program
    {
        public delegate void ActionCar();
        public static void Main(string[] args)
        {
            CarWash carWash1 = new CarWash()
            {
                CarWashName = "Shilo",
                WashCost = 2000
            };
            CarWash carWash2 = new CarWash()
            {
                CarWashName = "Milo",
                WashCost = 3000
            };

            Garage garage1 = new Garage(carWash1)
            {
                GarageName = "Romawka",
                GarageCapacity = 10
            };
            Garage garage2 = new Garage(carWash1)
            {
                GarageName = "Lutik",
                GarageCapacity = 15
            };
            Garage garage3 = new Garage(carWash2)
            {
                GarageName = "Oduvancik",
                GarageCapacity = 20
            };
            
            Car car1 = new Car(garage1)
            {
                CarMark = "Mercedes",
                CarModel = "S-model1",
                CarBodyType = "M-Type1",
                CarColor = Color.Black,
            };
            Car car2 = new Car(garage1)
            {
                CarMark = "Mercedes",
                CarModel = "C-model2",
                CarBodyType = "M-Type2",
                CarColor = Color.White,
            };
            Car car3 = new Car(garage2)
            {
                CarMark = "Subaru",
                CarModel = "Subaru-model1",
                CarBodyType = "S-Type1",
                CarColor = Color.Blue,
            };
            Car car4 = new Car(garage3)
            {
                CarMark = "BWM",
                CarModel = "X6",
                CarBodyType = "B-Type1",
                CarColor = Color.Black,
            };
            Car car5 = new Car(garage3)
            {   
                CarMark = "Toyota",
                CarModel = "T-Model1",
                CarBodyType = "T-Type1",
                CarColor = Color.Gray,
            };
            
            List<Car> cars = new List<Car>()
            {
                car1, car2, car3, car4, car5
            };
            ActionCar actionCar = null;

            foreach (var car in cars)
            {
                car.GetInfo();
                actionCar += car.WashCar;
                Console.WriteLine("------------------------------------------------------------");
            }
            
            actionCar.Invoke();
        }
        

        #region Events and delegates with EventArgs
        // public static void Main(string[] args)
        // {
        //     var mailMgr = new MailManager();
        //     mailMgr.NewMail += MailMngrMail;
        //
        //     Console.WriteLine("Enter your Name: ");
        //     var sender = Console.ReadLine();
        //
        //     Console.WriteLine("Enter friend's name: ");
        //     var target = Console.ReadLine();
        //
        //     Console.WriteLine("Enter your message");
        //     var subject = Console.ReadLine();
        //     
        //     mailMgr.SimulateNewMail(sender,target,subject);
        // }
        //
        // private static void MailMngrMail(object sender, MailEventArgs e)
        // {
        //     var sms = new Devices.SMS();
        //     sms.DeviceAction(e.Subject);
        //     
        //     var printer = new Devices.Printer();
        //     printer.DeviceAction(e.Subject);
        // }
        #endregion
        #region EventsTrying1
        // public static PersonEvents _somePerson;
        // public static void Main(string[] args)
        // {
        //     _somePerson = new PersonEvents()
        //     {
        //         Name = "Sasha"
        //     };
        //     _somePerson.PersonEvent+=_somePerson.MakeCoffee;
        //     _somePerson.InvokeMakeCoffee(true);
        // }
        // public class PersonEvents
        // {
        //     public string Name;
        //     public event Action PersonEvent;
        //
        //     public void InvokeMakeCoffee(bool shouldI)
        //     {
        //         if (shouldI)
        //         {
        //             PersonEvent.Invoke();
        //         }
        //         else
        //         {
        //             Console.WriteLine("Powel na huy");
        //         }
        //     }
        //
        //     public void MakeCoffee()
        //     {
        //         Console.WriteLine("Your coffee in the process");
        //     }
        // }
        #endregion
        #region Testing delegates

        
        // public delegate void SomeDelegate(string massege, int age);
        // static void Main(string[] args)
        // {
        //     SomeDelegate someDelegate = new SomeDelegate(SaySomething);
        //     someDelegate("Hello", 15);
        //
        //     Action<string, int> someAction;
        //     someAction = SaySomething;
        //     SomeFunc("Idi na huy",someAction);
        //     
        //     Func<int, string> someFuncDel = GetNameViaID;
        //     string tempString = someFuncDel?.Invoke(543795);
        //     Console.WriteLine(tempString);
        //
        // }
        //
        // public static void SaySomething(string sent,int age)
        // {
        //     Console.WriteLine(sent);
        //     Console.WriteLine($"My age is {age}");
        // }
        //
        // public static void SomeFunc(string message, Action<string, int> action)
        // {
        //     Console.WriteLine($"Writing {message} and calling Action");
        //     action.Invoke("Slim Shady", 15);
        // }
        //
        //
        // public static string GetNameViaID(int id)
        // {
        //     Console.WriteLine($"Your id is {id}");
        //     return $"id {id} is called DOLBAEB in real";
        // }
        #endregion
    }
}