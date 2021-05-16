using System;

namespace CS_Practices
{
    public class CarWash
    {
        #region Private fields
        
        private string _carWashName;
        private int _washCost;
        #endregion

        #region ctors
        public CarWash(){}
        #endregion
        
        public virtual void GetInfo()
        {
            Console.WriteLine($"Car wash name: {CarWashName}\n" +
                              $"Washing cost: {WashCost}\n");
        }
        public virtual object GetParentObject()
        {
            return this;
        }
        public virtual void WashCar()
        {
            this.GetInfo();
            Console.WriteLine($"Hope you have enjoyed\n");
            
        }

        #region Properties
        
        public string CarWashName
        {
            get => _carWashName;
            set => _carWashName = value;
        }
        public int WashCost
        {
            get => _washCost;
            set => _washCost = value;
        }
        #endregion
    }
}