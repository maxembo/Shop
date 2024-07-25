using System.Linq;
using Data;
using Skins;
using UnityEngine;
using UnityEngine.UI;
using Visitor;

namespace Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopContent _contentItems;
        [SerializeField] private ShopCategoryButton _characterSkinsButton, _mazeSkinsButton;
        [SerializeField] private ShopPanel _shopPanel;

        [SerializeField] private Buy _buyButton;
        [SerializeField] private Button _selection;
        [SerializeField] private Image _selectedText;

        [SerializeField] private SkinPlacement _skinPlacement;

        [SerializeField] private CameraPositionUpdater _cameraPositionUpdater;

        private IDataProvider _dataProvider;

        private ShopItemView _previewedItem;
        private Wallet.Wallet _wallet;

        private SkinSelector _skinSelector;
        private SkinUnlocker _skinUnlock;
        private OpenSkinsChecker _openSkinsChecker;
        private SelectedSkinsChecker _selectedSkinsChecker;

        private void OnEnable()
        {
            _characterSkinsButton.Click += OnCharacterSkinsButtonClick;
            _mazeSkinsButton.Click += OnMazeSkinsButtonClick;

            _buyButton.Click += OnBuyClick;
            _selection.onClick.AddListener(OnSelectionClick);
        }

        private void OnDisable()
        {
            _characterSkinsButton.Click -= OnCharacterSkinsButtonClick;
            _mazeSkinsButton.Click -= OnMazeSkinsButtonClick;

            _buyButton.Click -= OnBuyClick;
            _shopPanel.ItemViewClicked -= OnItemViewClicked;
            _selection.onClick.RemoveListener(OnSelectionClick);
        }

        public void Initialize(IDataProvider dataProvider, Wallet.Wallet wallet, OpenSkinsChecker openSkinsChecker,
            SelectedSkinsChecker selectedSkinsChecker, SkinSelector skinSelector,
            SkinUnlocker skinUnlock)
        {
            _wallet = wallet;
            _openSkinsChecker = openSkinsChecker;
            _selectedSkinsChecker = selectedSkinsChecker;
            _skinSelector = skinSelector;
            _skinUnlock = skinUnlock;

            _dataProvider = dataProvider;

            _shopPanel.Initialize(openSkinsChecker, selectedSkinsChecker);

            _shopPanel.ItemViewClicked += OnItemViewClicked;

            OnCharacterSkinsButtonClick();
        }

        private void OnItemViewClicked(ShopItemView item)
        {
            _previewedItem = item;

            _skinPlacement.InstaniateModel(_previewedItem.Item.Model);

            _openSkinsChecker.Visit(_previewedItem.Item);

            if (_openSkinsChecker.IsOpened)
            {
                _selectedSkinsChecker.Visit(_previewedItem.Item);

                if (_selectedSkinsChecker.IsSelected)
                {
                    ShowSelectedText();
                    return;
                }

                ShowSelection();
            }
            else
            {
                ShowBuy(_previewedItem.Price);
            }
        }

        private void OnBuyClick()
        {
            if (!_wallet.IsEnough(_previewedItem.Price)) return;

            _wallet.Spend(_previewedItem.Price);

            _skinUnlock.Visit(_previewedItem.Item);

            SelectSkin();

            _previewedItem.Unlock();

            _dataProvider.Save();
        }

        private void OnSelectionClick()
        {
            SelectSkin();

            _dataProvider.Save();
        }

        private void SelectSkin()
        {
            _skinSelector.Visit(_previewedItem.Item);
            _shopPanel.Select(_previewedItem);
            ShowSelectedText();
        }

        private void ShowSelectedText()
        {
            _selectedText.gameObject.SetActive(true);
            HideSelection();
            HideBuy();
        }

        private void ShowSelection()
        {
            _selection.gameObject.SetActive(true);
            HideBuy();
            HideSelectedText();
        }

        private void ShowBuy(int price)
        {
            _buyButton.gameObject.SetActive(true);
            _buyButton.UpdateText(price);

            if (_wallet.IsEnough(price))
                _buyButton.UnLock();
            else
                _buyButton.Lock();

            HideSelectedText();
            HideSelection();
        }

        private void OnMazeSkinsButtonClick()
        {
            _mazeSkinsButton.Select();
            _characterSkinsButton.UnSelect();

            _cameraPositionUpdater.UpdateCameraPosition(_cameraPositionUpdater.MazeCategoryCameraPosition);
            
            _shopPanel.Show(_contentItems.MazeSkinItems.Cast<ShopItem>());
        }

        private void OnCharacterSkinsButtonClick()
        {
            _mazeSkinsButton.UnSelect();
            _characterSkinsButton.Select();
            
            _cameraPositionUpdater.UpdateCameraPosition(_cameraPositionUpdater.CharacterCategoryCameraPosition);
            
            _shopPanel.Show(_contentItems.CharacterSkinItems.Cast<ShopItem>());
        }

        private void HideBuy() => _buyButton.gameObject.SetActive(false);
        private void HideSelection() => _selection.gameObject.SetActive(false);
        private void HideSelectedText() => _selectedText.gameObject.SetActive(false);
    }
}