using System;
using System.Collections.Generic;
using System.Linq;
using Skins.CharacterSkins;
using Skins.MazeSkins;

namespace Data
{
    public class PlayerData
    {
        private CharacterSkins _selectedCharacterSkin;
        private MazeSkins _selectedMazeSkins;

        private List<CharacterSkins> _openCharacterSkins;
        private List<MazeSkins> _openMazeSkins;

        private int _money;

        public PlayerData(PlayerDataConfig config)
        {
            _money = config.Money;

            _selectedCharacterSkin = config.SelectedCharacterSkin;
            _selectedMazeSkins = config.SelectedMazeSkin;

            _openCharacterSkins = new List<CharacterSkins>() { _selectedCharacterSkin };
            _openMazeSkins = new List<MazeSkins>() { _selectedMazeSkins };
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
            get => _selectedMazeSkins;
            set
            {
                if (_openMazeSkins.Contains(value) == false)
                    throw new ArgumentException(nameof(value));

                _selectedMazeSkins = value;
            }
        }

        public IEnumerable<CharacterSkins> OpenCharacterSkins => _openCharacterSkins;

        public IEnumerable<MazeSkins> OpenMazeSkins => _openMazeSkins;

        public void OpenCharacterSKin(CharacterSkins characterSkin)
        {
            if (_openCharacterSkins.Contains(characterSkin))
                throw new ArgumentException(nameof(characterSkin));

            _openCharacterSkins.Add(characterSkin);
        }

        public void OpenMazeSKin(MazeSkins mazeSkin)
        {
            if (_openMazeSkins.Contains(mazeSkin))
                throw new ArgumentException(nameof(mazeSkin));

            _openMazeSkins.Add(mazeSkin);
        }
    }
}