namespace ActionContract
{
    public class ActionLocation
    {
        private readonly int _floor;
        private readonly int _corridor;

        public ActionLocation(int floor, int subcorridor)
        {
            _floor = floor;
            _corridor = subcorridor;
        }
        
        public int Floor => _floor - 1;
        public int SubCorridor => _corridor - 1;
        public int MainCorridor => _corridor - 1;
    }
}