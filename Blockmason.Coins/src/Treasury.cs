using Blockmason.Link;
using System;
using System.Threading.Tasks;

namespace Blockmason.Coins {
	public class Treasury {
		public class BalanceContract {
			public int amount;
		}

		private string m_ClientId;
		private string m_ClientSecret;
		private bool m_ReadOnly;
		private Project m_Project;

		public bool ReadOnly { get { return m_ReadOnly; } set { m_ReadOnly = value; } }

		public Treasury(string clientId, string clientSecret) {
			m_ClientId = clientId;
			m_ClientSecret = clientSecret;
		}

		private async Task<Project> GetProject() {
			if (m_Project == null) {
				m_Project = await Project.Create(m_ClientId, m_ClientSecret);
			}

			return m_Project;
		}

		public async Task<int> Balance(int holder) {
			Project project = await GetProject();
			BalanceContract balance = await project.Get<BalanceContract>("/balance", new { holder = holder });
			return balance.amount;
		}

		public async Task<int> Burn(int holder, int amount) {
			if (!ReadOnly) {
				Project project = await GetProject();

				await project.Post<object>("/burn", new {
					amount = amount,
					holder = holder
				});

				return amount;
			}

			return 0;
		}

		public async Task<Coin> Mint(int holder, int amount) {
			if (!ReadOnly) {
				Project project = await GetProject();
				await project.Post<object>("/mint", new { amount = amount, holder = holder });
				return new Coin(holder, amount);
			}

			return null;
		}

		public async Task<int> Transfer(Coin coin, int newHolder) {
			if (!ReadOnly) {
				if (coin.Holder != newHolder) {
					Project project = await GetProject();

					await project.Post<object>("/transfer", new {
						amount = coin.Amount,
						from = coin.Holder,
						to = newHolder
					});
				}

				return coin.Amount;
			}

			return 0;
		}
	}
}
