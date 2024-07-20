using Skins;
using Visitor;
using UnityEngine;

namespace Factory
{
    [CreateAssetMenu(fileName = "ShopItemViewFactory", menuName = "Shop/ShopItemViewFactory")]
    public class ShopItemViewFactory : ScriptableObject
    {
        [SerializeField] private ShopItemView _characterSkinItemPrefab;
        [SerializeField] private ShopItemView _mazeSkinItemPrefab;

        public ShopItemView Get(ShopItem shopItem, Transform parent)
        {
            ShopItemVisitor visitor = new ShopItemVisitor(_characterSkinItemPrefab, _mazeSkinItemPrefab);
            visitor.Visit(shopItem);

            ShopItemView instance = Instantiate(visitor.Prefab, parent);
            instance.Initialize(shopItem);

            return instance;
        }

        private class ShopItemVisitor : IShopItemVisitor
        {
            public ShopItemView Prefab { get; private set; }

            private readonly ShopItemView _characterSkinItemPrefab;
            private readonly ShopItemView _mazeSkinItemPrefab;

            public ShopItemVisitor(ShopItemView characterSkinItemPrefab, ShopItemView mazeSkinItemPrefab)
            {
                _characterSkinItemPrefab = characterSkinItemPrefab;
                _mazeSkinItemPrefab = mazeSkinItemPrefab;
            }

            public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

            public void Visit(CharacterSkinItem characterSkinItem) => Prefab = _characterSkinItemPrefab;

            public void Visit(MazeSkinItem mazeSkinItem) => Prefab = _mazeSkinItemPrefab;
        }
    }
}