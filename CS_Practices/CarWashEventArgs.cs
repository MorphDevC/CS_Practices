using   System;

namespace CS_Practices
{
    public class CarWashEventArgs:EventArgs
    {
        public Car AnyCar { get; }
        public Garage CarGarage { get; }
        public CarWash CarWash { get; }

        public CarWashEventArgs(Car car,Garage garage, CarWash carWash)
        {
            AnyCar = car;
            CarGarage = garage;
            CarWash = carWash;
        }
    }
}