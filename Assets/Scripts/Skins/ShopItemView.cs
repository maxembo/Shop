using System;
using Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Skins
{
    [RequireComponent(typeof(Image))]
    public class ShopItemView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<ShopItemView> Click;

        [SerializeField] private Sprite _standart, _highlight;
        [SerializeField] private Image _content;
        [SerializeField] private Image _lock;
        [SerializeField] private IntValueView _priceView;
        [SerializeField] private Image _selectionText;

        private Image _backgroundImage;

        public ShopItem Item { get; private set; }

        public bool IsLock { get; private set; }

        public int Price => Item.Price;
        public GameObject Model => Item.Model;

        public void Initialize(ShopItem item)
        {
            _backgroundImage = GetComponent<Image>();
            _backgroundImage.sprite = _standart;

            Item = item;

            _content.sprite = item.Image;

            _priceView.Show(Price);
        }

        public void OnPointerClick(PointerEventData eventData) => Click?.Invoke(this);

        public void Lock()
        {
            IsLock = true;
            _lock.gameObject.SetActive(IsLock);
            _priceView.Show(Price);
        }

        public void UnLock()
        {
            IsLock = false;
            _lock.gameObject.SetActive(IsLock);
            _priceView.Hide();
        }

        public void Select() => _selectionText.gameObject.SetActive(true);

        public void UnSelect() => _selectionText.gameObject.SetActive(false);

        public void Highlight() => _backgroundImage.sprite = _highlight;

        public void UnHighlight() => _backgroundImage.sprite = _standart;
    }
}