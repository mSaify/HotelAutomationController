namespace HotelEntities
{
    public class Light : ElectronicAppliance
    {
        private const int DefaultpowerConsumption = 5;
        public Light()
        {
            PowerConsumption = DefaultpowerConsumption;
            base.SwitchOn();
        }

        public Light(int powerConsumption)
        {
            PowerConsumption = powerConsumption;
            base.SwitchOn();
        }
    }
}