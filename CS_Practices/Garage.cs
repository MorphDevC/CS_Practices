using System;

namespace CS_Practices
{
    public class Garage:CarWash
    {
        #region private fields
        
        private string _garageName;
        private int _garageCapacity;
        #endregion

        #region ctors
        
        public Garage(){}
        public Garage(CarWash carWash)
        {
            CarWashName = carWash.CarWashName;
            WashCost = carWash.WashCost;
        }
        #endregion
        public override void GetInfo()
        {
            Console.WriteLine($"Garage name: {GarageName}\n" +
                              $"Capacity this garage: {GarageCapacity}");
            base.GetInfo();
        }

        public CarWash GetCarWash()
        {
            if(GetParentObject() is CarWash)
                return (CarWash)GetParentObject();
            else
            {
                return null;
            }
        }
        public override object GetParentObject()
        {
            return this;
        }
        

        #region Properties
        
        public string GarageName
        {
            get => _garageName;
            set => _garageName = value;
        }
        public int GarageCapacity
        {
            get => _garageCapacity;
            set => _garageCapacity = value;
        }
        #endregion
    }
}