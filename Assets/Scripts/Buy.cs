using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Color _lock;
    [SerializeField] private Color _unlock;

    [SerializeField, Range(0, 1)] private float _lockAnimationDuration = 0.4f;
    [SerializeField, Range(0.5f, 5f)] private float _lockAnimationStrength = 2f;

    public event Action Click;
    private bool _isLock;

    private void OnEnable() => _button.onClick.AddListener(OnButtonClick);
    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    public void UpdateText(int price) => _text.text = price.ToString();

    public void Lock()
    {
        _isLock = true;
        _text.color = _lock;
    }

    public void UnLock()
    {
        _isLock = false;
        _text.color = _unlock;
    }
    
    private void OnButtonClick()
    {
        if (_isLock)
        {
            transform.DOShakePosition(_lockAnimationDuration, _lockAnimationStrength);
            return;
        }

        Click?.Invoke();
    }
}