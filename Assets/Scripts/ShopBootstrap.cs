using Data;
using UnityEngine;
using Visitor;

public class ShopBootstrap : MonoBehaviour
{
	[SerializeField] private Shop _shop;
	[SerializeField] private PlayerDataConfig _config;

	private IDataProvider _dataProvider;
	private IPersistentData _persistentData;

	private Wallet.Wallet _wallet;

	private void Awake()
	{
		InitializeData();
		InitializeWallet();
		InitializeShop();
	}

	private void InitializeData()
	{
		_persistentData = new PersistentData();
		_dataProvider = new DataLocalProvider(_persistentData);

		LoadDataOrInit();
	}

	private void InitializeWallet()
	{
		_wallet = new Wallet.Wallet(_persistentData);
	}

	private void InitializeShop()
	{
		OpenSkinsChecker openSkinsChecker = new OpenSkinsChecker(_persistentData);
		SelectedSkinsChecker selectedSkinsChecker = new SelectedSkinsChecker(_persistentData);
		SkinSelector skinSelector = new SkinSelector(_persistentData);
		SkinUnlocker skinUnlock = new SkinUnlocker(_persistentData);

		_shop.Initialize(_dataProvider, _wallet, openSkinsChecker, selectedSkinsChecker, skinSelector, skinUnlock);
	}

	private void LoadDataOrInit()
	{
		if (_dataProvider.TryLoad() == false)
			_persistentData.PlayerData = new PlayerData(_config);
	}
}