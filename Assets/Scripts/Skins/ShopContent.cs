using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "ShopContent", menuName = "Shop/ShopContent")]
    public class ShopContent : ScriptableObject
    {
        [SerializeField] private List<CharacterSkinItem> _characterSkinItems = new List<CharacterSkinItem>();
        [SerializeField] private List<MazeSkinItem> _mazeSkinItems = new List<MazeSkinItem>();

        public IEnumerable<CharacterSkinItem> CharacterSkinItems => _characterSkinItems;
        public IEnumerable<MazeSkinItem> MazeSkinItems => _mazeSkinItems;

        private void OnValidate()
        {
            EditorApplication.delayCall += () =>
            {
                CheckDuplicates(_characterSkinItems, item => item.SkinType);
                CheckDuplicates(_mazeSkinItems, item => item.SkinType);
            };
        }

        private void CheckDuplicates<T, TKey>(List<T> skins, Func<T, TKey> keySelector)
        {
            if (skins.Count < 1) return;

            var duplicates = skins
                .GroupBy(keySelector)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key);
                
            foreach (var duplicate in duplicates)
            {
                Debug.LogError($"Duplicate found: {duplicate}");
            }
        }

    }
}
