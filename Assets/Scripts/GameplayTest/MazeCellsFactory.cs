using System;
using Skins.CharacterSkins;
using Skins.MazeSkins;
using UnityEngine;

namespace GameplayTest
{
    [CreateAssetMenu(fileName = "MazeCellsFactory", menuName = "GameplayExample/MazeCellsFactory")]
    public class MazeCellsFactory : ScriptableObject
    {
        [SerializeField] private MazeCell _egypt;
        [SerializeField] private MazeCell _jungle;
        [SerializeField] private MazeCell _treasury;
        [SerializeField] private MazeCell _green;
        [SerializeField] private MazeCell _cristal;
        [SerializeField] private MazeCell _flower;

        public MazeCell Get(MazeSkins skinType, Vector3 spawnPosition)
        {
            MazeCell instance = Instantiate(GetPrefab(skinType), spawnPosition, Quaternion.identity);
            instance.Initialize();
            return instance;
        }

        private MazeCell GetPrefab(MazeSkins skinType)
        {
            return skinType switch
            {
                MazeSkins.Egypt => _egypt,
                MazeSkins.Jungle => _jungle,
                MazeSkins.Treasury => _treasury,
                MazeSkins.Green => _green,
                MazeSkins.Cristal => _cristal,
                MazeSkins.Flower => _flower,
                _ => throw new ArgumentException(nameof(skinType))
            };
        }
    }
}