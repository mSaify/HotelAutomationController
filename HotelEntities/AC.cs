namespace HotelEntities
{
    public class AC : ElectronicAppliance
    {
       
        public AC(int powerConsumption)
        {
            PowerConsumption = powerConsumption;
            base.SwitchOn();
        }

        public AC()
        {
            PowerConsumption = 10;
            base.SwitchOn();
        }   
    }
}
