using UnityEngine;
using Skins;
using System.Collections.Generic;
using Factory;
using System;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private List<ShopItemView> _shopItems = new List<ShopItemView>();
    [SerializeField] private ShopItemViewFactory _shopItemViewFactory;
    [SerializeField] private Transform _itemsParents;

    public void Show(IEnumerable<ShopItem> items)
    {
        Clear();

        foreach(ShopItem item in items)
        {
            ShopItemView spawnedItem = _shopItemViewFactory.Get(item, _itemsParents);

            spawnedItem.Click += OnItemViewClick;

            spawnedItem.UnSelect();
            spawnedItem.UnHighlight();

            _shopItems.Add(spawnedItem);
        }
    }

    private void OnItemViewClick(ShopItemView obj)
    {
        throw new NotImplementedException();
    }

    private void Clear()
    {
        foreach(ShopItemView itemView in _shopItems)
        {
            itemView.Click -= OnItemViewClick;
            Destroy(itemView.gameObject);
        }

        _shopItems.Clear();
    }
}

