using System;

namespace Blockmason.Coins {
	public class Coin {
		private int m_Amount;
		private int m_Holder;

		public int Amount { get { return m_Amount; } set { m_Amount = value; } }

		public int Holder { get { return m_Holder; } set { m_Holder = value; } }

		public Coin(int holder, int amount) {
			m_Holder = holder;
			m_Amount = amount;
		}
	}
}
