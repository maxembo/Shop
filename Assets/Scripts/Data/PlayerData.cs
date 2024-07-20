using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Skins.CharacterSkins;
using Skins.MazeSkins;

namespace Data
{
    public class PlayerData
    {
        private CharacterSkins _selectedCharacterSkin;
        private MazeSkins _selectedMazeSkin;

        private readonly List<CharacterSkins> _openCharacterSkins;
        private readonly List<MazeSkins> _openMazeSkins;

        private int _money;

        public PlayerData(PlayerDataConfig config)
        {
            _money = config.Money;

            _selectedCharacterSkin = config.SelectedCharacterSkin;
            _selectedMazeSkin = config.SelectedMazeSkin;

            _openCharacterSkins = new List<CharacterSkins>() { _selectedCharacterSkin };
            _openMazeSkins = new List<MazeSkins>() { _selectedMazeSkin };
        }

        [JsonConstructor]
        public PlayerData(int money, CharacterSkins selectedCharacterSkin,MazeSkins selectedMazeSkin, List<CharacterSkins> openCharacterSkins, List<MazeSkins> openMazeSkins)
        {
            Money = money;

            _selectedCharacterSkin = selectedCharacterSkin;
            _selectedMazeSkin = selectedMazeSkin;

            _openCharacterSkins = new List<CharacterSkins>(openCharacterSkins);
            _openMazeSkins = new List<MazeSkins>(openMazeSkins);
        }

        public int Money
        {
            get => _money;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _money = value;
            }
        }

        public CharacterSkins SelectedCharacterSkin
        {
            get => _selectedCharacterSkin;
            set
            {
                if (_openCharacterSkins.Contains(value) == false)
                    throw new ArgumentException(nameof(value));

                _selectedCharacterSkin = value;
            }
        }

        public MazeSkins SelectedMazeSkin
        {
            get => _selectedMazeSkin;
            set
            {
                if (_openMazeSkins.Contains(value) == false)
                    throw new ArgumentException(nameof(value));

                _selectedMazeSkin = value;
            }
        }

        public IEnumerable<CharacterSkins> OpenCharacterSkins => _openCharacterSkins;

        public IEnumerable<MazeSkins> OpenMazeSkins => _openMazeSkins;

        public void OpenCharacterSkin(CharacterSkins characterSkin)
        {
            if (_openCharacterSkins.Contains(characterSkin))
                throw new ArgumentException(nameof(characterSkin));

            _openCharacterSkins.Add(characterSkin);
        }

        public void OpenMazeSkin(MazeSkins mazeSkin)
        {
            if (_openMazeSkins.Contains(mazeSkin))
                throw new ArgumentException(nameof(mazeSkin));

            _openMazeSkins.Add(mazeSkin);
        }
    }
}