using System;
using System.Drawing;

namespace CS_Practices
{
    public class Car:Garage
    {
        #region private fields
        
        private string _carMark;
        private string _carModel;
        private string _carBodyType;
        private Color _carColor;
        #endregion

        #region ctors
        
        public Car(){}
        public Car(Garage garage):this(garage,garage.GetCarWash()) { }
        public Car(Garage garage,CarWash carWash):base(carWash)
        {
            GarageName = garage.GarageName;
            GarageCapacity = garage.GarageCapacity;
        }
        #endregion

        public override void GetInfo()
        {
            Console.WriteLine($"Car mark: {CarMark}\n" +
                              $"Car model: {CarModel}\n" +
                              $"Car body type: {CarBodyType}\n" +
                              $"Car Color: {CarColor}");
            base.GetInfo();
        }


        #region Properties
        
        public string CarMark
        {
            get => _carMark;
            set => _carMark = value;
        }
        public string CarModel
        {
            get => _carModel;
            set => _carModel = value;
        }
        public string CarBodyType
        {
            get => _carBodyType;
            set => _carBodyType = value;
        }
        public Color CarColor
        {
            get => _carColor;
            set => _carColor = value;
        }
        #endregion
    }
}