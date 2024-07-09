using System;
using System.Linq;
using Skins;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopContent _contentItems;
    [SerializeField] private ShopCategoryButton _characterSkinsButton, _mazeSkinsButton;
    [SerializeField] private ShopPanel _shopPanel;

    private void OnEnable()
    {
        _characterSkinsButton.Click += OnCharacterSkinsButtonClick;
        _mazeSkinsButton.Click += OnMazeSkinsButtonClick;
    }

    private void OnDisable()
    {
        _characterSkinsButton.Click -= OnCharacterSkinsButtonClick;
        _mazeSkinsButton.Click -= OnMazeSkinsButtonClick;
    }

    private void OnMazeSkinsButtonClick()
    {
        _mazeSkinsButton.Select();
        _characterSkinsButton.UnSelect();
        _shopPanel.Show(_contentItems.MazeSkinItems.Cast<ShopItem>());
    }

    private void OnCharacterSkinsButtonClick()
    {
        _mazeSkinsButton.UnSelect();
        _characterSkinsButton.Select();
        _shopPanel.Show(_contentItems.CharacterSkinItems.Cast<ShopItem>());
    }
}
