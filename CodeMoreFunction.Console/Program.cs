using CodeMoreFunction.Core;
using System;

namespace CodeMoreFunction.Console
{
    class Program
    {
        static void Main(string[] args)
        {            
            Wallet wallet = new Wallet();
            wallet.Charge(Currency.USD, Amount.Zero(Currency.USD));
        }
    }
}
