namespace HotelEntities
{
    public class MainCorridor : Corridor
    {
        public virtual MainCorridor With(Light light, AC ac)
        {
            base.Lights.Add(light);
            base.Acs.Add(ac);
            return this;
        }

        public virtual MainCorridor With(Light light)
        {
            Lights.Add(light);
            return this;
        }

        public virtual MainCorridor With(AC ac)
        {
            Acs.Add(ac);
            return this;
        }
    }

}
