using System;
using Data;

namespace Wallet
{
	public class Wallet
	{
		public event Action<int> CoinsChanged;

		private readonly IPersistentData _persistentData;

		public Wallet(IPersistentData persistentData) => _persistentData = persistentData;

		public void Add(int coins)
		{
			if (coins < 0) throw new ArgumentOutOfRangeException(nameof(coins));

			_persistentData.PlayerData.Money += coins;

			CoinsChanged?.Invoke(_persistentData.PlayerData.Money);
		}

		public void Spend(int coins)
		{
            if (coins < 0) throw new ArgumentOutOfRangeException(nameof(coins));

            _persistentData.PlayerData.Money -= coins;

            CoinsChanged?.Invoke(_persistentData.PlayerData.Money);
        }

		public bool IsEnough(int coins)
		{
            if (coins < 0) throw new ArgumentOutOfRangeException(nameof(coins));

			return _persistentData.PlayerData.Money >= coins;
        }

		public int GetCurrentCoins() => _persistentData.PlayerData.Money;
	}
}