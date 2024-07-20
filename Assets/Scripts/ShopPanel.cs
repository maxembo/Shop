using UnityEngine;
using Skins;
using System.Collections.Generic;
using Factory;
using System;
using Visitor;

public class ShopPanel : MonoBehaviour
{
	[SerializeField] private ShopItemViewFactory _shopItemViewFactory;
	[SerializeField] private Transform _itemsParent;

	public event Action<ShopItemView> ItemViewClicked;

	private List<ShopItemView> _shopItems = new List<ShopItemView>();
	
	private OpenSkinsChecker _openSkinsChecker;
	private SelectedSkinsChecker _selectedSkinChecker;

	public void Initialize(OpenSkinsChecker openSkinsChecker, SelectedSkinsChecker selectedSkinsChecker)
	{
		_openSkinsChecker = openSkinsChecker;
		_selectedSkinChecker = selectedSkinsChecker;
	}

	public void Show(IEnumerable<ShopItem> items)
	{
		Clear();

		foreach (ShopItem item in items)
		{
			ShopItemView spawnedItem = _shopItemViewFactory.Get(item, _itemsParent);

			spawnedItem.Click += OnItemViewClick;

			spawnedItem.UnSelect();
			spawnedItem.UnHighlight();

			_openSkinsChecker.Visit(spawnedItem.Item);

			if (_openSkinsChecker.IsOpened)
			{
				_selectedSkinChecker.Visit(spawnedItem.Item);

				if (_selectedSkinChecker.IsSelected)
				{
					spawnedItem.Select();
					spawnedItem.Highlight();
					ItemViewClicked?.Invoke(spawnedItem);
				}

				spawnedItem.Unlock();
			}
			else
			{
				spawnedItem.Lock();
			}

			_shopItems.Add(spawnedItem);
		}
	}

	public void Select(ShopItemView itemView)
	{
		foreach (var item in _shopItems)
			item.UnSelect();

		itemView.Select();
	}

	private void OnItemViewClick(ShopItemView itemView)
	{
		Highlight(itemView);
		ItemViewClicked?.Invoke(itemView);
	}

	private void Highlight(ShopItemView shopItemView)
	{
		foreach (var item in _shopItems)
			item.UnHighlight();

		shopItemView.Highlight();
	}

	private void Clear()
	{
		foreach (ShopItemView itemView in _shopItems)
		{
			itemView.Click -= OnItemViewClick;
			Destroy(itemView.gameObject);
		}

		_shopItems.Clear();
	}
}