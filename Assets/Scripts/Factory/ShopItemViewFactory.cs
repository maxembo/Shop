using System;
using Skins;
using UnityEngine;

namespace Factory
{
    [CreateAssetMenu(fileName = "ShopItemViewFactory", menuName ="Shop/ShopItemViewFactory")]
    public class ShopItemViewFactory : ScriptableObject
    {
        [SerializeField] private ShopItemView _characterSkinItemPrefab;
        [SerializeField] private ShopItemView _mazeSkinItemPrefab;

        public ShopItemView Get(ShopItem shopItem, Transform parent)
        {
            ShopItemView instance = shopItem switch
            {
                CharacterSkinItem => Instantiate(_characterSkinItemPrefab, parent),
                MazeSkinItem => Instantiate(_mazeSkinItemPrefab, parent),
                _ => throw new ArgumentException(nameof(shopItem)),
            };

            instance.Initialize(shopItem);
            return instance;
        }

    }
}
