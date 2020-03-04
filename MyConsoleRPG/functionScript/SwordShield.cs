namespace MyConsoleRPG
{
    internal class SwordShield : Function
    {
        public SwordShield()
        {
            Name = string.Format("防剑诀");
            FunType = TheFiveElements.Gold;
            Value = 10;
            FunCard = typeof( GiveShieldCard).Name;
        }
    }
}