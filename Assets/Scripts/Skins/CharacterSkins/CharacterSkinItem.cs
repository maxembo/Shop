using UnityEngine;

namespace Skins
{
	[CreateAssetMenu(fileName ="CharacterSkinItem", menuName ="Shop/CharacterSkinItem")]
	public class CharacterSkinItem : ShopItem
	{
        [field: SerializeField] public CharacterSkins.CharacterSkins SkinType { get; private set; }
	}
}