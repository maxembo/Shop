using Skins.CharacterSkins;
using Skins.MazeSkins;
using UnityEngine;

namespace Data
{
	[CreateAssetMenu(fileName = "PlayerDataConfig", menuName = "Data/PlayerDataConfig")]
	public class PlayerDataConfig : ScriptableObject
	{
		[field: SerializeField] public CharacterSkins SelectedCharacterSkin { get; private set; }
		[field: SerializeField] public MazeSkins SelectedMazeSkin { get; private set; }
		[field: SerializeField,Range(0,10_000)] public int Money { get; private set; }
    }

}