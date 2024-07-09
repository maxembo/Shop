using UnityEngine;

namespace Skins
{
	[CreateAssetMenu(fileName ="MazeSkinItem", menuName ="Shop/MazeSkinItem")]
	public class MazeSkinItem : ShopItem
	{
		[field: SerializeField] public MazeSkins.MazeSkins SkinType { get; private set; }
	}
}