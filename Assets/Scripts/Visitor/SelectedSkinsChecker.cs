using Data;
using Skins;

namespace Visitor
{
	public class SelectedSkinsChecker : IShopItemVisitor
	{
        public bool IsSelected { get; private set; }

        private readonly IPersistentData _persistentData;

        public SelectedSkinsChecker(IPersistentData persistentData) => _persistentData = persistentData;

        public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

        public void Visit(CharacterSkinItem characterSkinItem)
            => IsSelected = _persistentData.PlayerData.SelectedCharacterSkin == characterSkinItem.SkinType;

        public void Visit(MazeSkinItem mazeSkinItem)
            => IsSelected = _persistentData.PlayerData.SelectedMazeSkin == mazeSkinItem.SkinType;
    }
}

