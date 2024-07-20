using System.Linq;
using Data;
using Skins;

namespace Visitor
{
	public class OpenSkinsChecker : IShopItemVisitor
	{
        public bool IsOpened { get; private set; }

        private readonly IPersistentData _peristentData;

		public OpenSkinsChecker(IPersistentData persistentData) => _peristentData = persistentData;

        public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

        public void Visit(CharacterSkinItem characterSkinItem)
            => IsOpened = _peristentData.PlayerData.OpenCharacterSkins.Contains(characterSkinItem.SkinType);
        
        public void Visit(MazeSkinItem mazeSkinItem)
            => IsOpened = _peristentData.PlayerData.OpenMazeSkins.Contains(mazeSkinItem.SkinType);
    }
}
