namespace HotelEntities
{
    public class SubCorridor : Corridor
    {
        public virtual SubCorridor With(Light light, AC ac)
        {
            base.Lights.Add(light);
            base.Acs.Add(ac);
            return this;
        }

        public virtual SubCorridor With(Light light)
        {
            this.Lights.Add(light);
            return this;
        }

        public virtual SubCorridor With(AC ac)
        {
            this.Acs.Add(ac);
            return this;
        }
    }
}