using System;
using System.Collections.Generic;
using System.Text;

namespace CodeMoreFunction.Core
{
    public class Wallet
    {
        private IList<Money> Content { get; set; } = new List<Money>();

        public void Add(Money money)
        {
            this.Content.Add(money ?? throw new ArgumentNullException(nameof(money)));
        }




    }
}
