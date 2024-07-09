using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopCategoryButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private Color _select;
    [SerializeField] private Color _unselect;

    public event Action Click;

    private void OnEnable() => _button.onClick.AddListener(OnClick);

    private void OnDisable () => _button.onClick.RemoveListener(OnClick);

    public void Select() => _image.color = _select;

    public void UnSelect() => _image.color = _unselect;

    private void OnClick() => Click?.Invoke();
}
