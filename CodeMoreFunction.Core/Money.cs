namespace CodeMoreFunction.Core
{
    public abstract class Money
    {
        public abstract Money On(Timestamp time);
        public abstract SpecificMoney Of(Currency currency);
    }
}