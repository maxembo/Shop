using System;
using System.Collections.Generic;
using Skins.CharacterSkins;
using UnityEngine;

namespace GameplayTest
{
    [CreateAssetMenu(fileName = "CharacterFactory", menuName = "GameplayExample/CharacterFactory")]
    public class CharacterFactory : ScriptableObject
    {
        [SerializeField] private Character _viking;
        [SerializeField] private Character _cat;
        [SerializeField] private Character _bat;
        [SerializeField] private Character _duck;
        [SerializeField] private Character _ghost;
        [SerializeField] private Character _rabbit;
        [SerializeField] private Character _penguin;
        [SerializeField] private Character _beaver;
        [SerializeField] private Character _sheep;
        [SerializeField] private Character _flower;
        [SerializeField] private Character _slime;
        [SerializeField] private Character _anubis;


        public Character Get(CharacterSkins skinType, Vector3 spawnPosition)
        {
            Character instance = Instantiate(GetPrefab(skinType), spawnPosition, Quaternion.identity);
            instance.Initialize();
            return instance;
        }

        private Character GetPrefab(CharacterSkins skinType)
        {
            return skinType switch
            {
                CharacterSkins.Viking => _viking,
                CharacterSkins.Cat => _cat,
                CharacterSkins.Bat => _bat,
                CharacterSkins.Duck => _duck,
                CharacterSkins.Ghost => _ghost,
                CharacterSkins.Rabbit => _rabbit,
                CharacterSkins.Penguin => _penguin,
                CharacterSkins.Beaver => _beaver,
                CharacterSkins.Sheep => _sheep,
                CharacterSkins.Flower => _flower,
                CharacterSkins.Slime => _slime,
                CharacterSkins.Anubis => _anubis,
                _ => throw new ArgumentException(nameof(skinType))
            };
        }
    }
}