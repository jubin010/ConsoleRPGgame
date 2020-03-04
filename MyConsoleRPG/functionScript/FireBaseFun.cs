namespace MyConsoleRPG
{
    internal class FireBaseFun : Function
    {
       
        public FireBaseFun(Quality Q)
        {
            switch (Q)
            {
                case Quality.凡品:
                    Value = 4;
                    break;
                case Quality.地品:
                    Value = 5;
                    break;
                case Quality.天品:
                    Value = 6;
                    break;
            }
            Name = string.Format("{0}火灵根", Q);
            FunType = TheFiveElements.Fire;

        }
    }
}