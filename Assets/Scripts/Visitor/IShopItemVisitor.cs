
using Skins;

namespace Visitor
{
    public interface IShopItemVisitor
    {
        public void Visit(ShopItem shopItem);
        public void Visit(CharacterSkinItem characterSkinItem);
        public void Visit(MazeSkinItem mazeSkinItem);
    }
}

