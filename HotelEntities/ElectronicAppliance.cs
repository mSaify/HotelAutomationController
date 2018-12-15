namespace HotelEntities
{
    public abstract class ElectronicAppliance
    {
        public Switch Switch { get; set; }

        public int PowerConsumption { get; set; }
        
        public virtual void SwitchOn()
        {
            Switch = Switch.ON;
        }

        public virtual void SwichOff()
        {
            Switch = Switch.OFF;
        }

        public virtual bool IsOn()
        {
           return Switch == Switch.ON;
        }
    }
}
