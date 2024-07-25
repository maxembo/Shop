using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    [RequireComponent(typeof(RawImage))]
    public class Scroller : MonoBehaviour
    {
        [SerializeField,Range(0,10)] private float _speed = 0.1f;
        [SerializeField, Range(-1, 1)] private float _xDirection;
        [SerializeField, Range(-1, 1)] private float _yDirection;

        private RawImage _image;

        private void Awake() => _image = GetComponent<RawImage>();

        private void Update() =>
            _image.uvRect = new Rect(
                _image.uvRect.position + new Vector2(-_xDirection * _speed, _yDirection * _speed) * Time.deltaTime,
                _image.uvRect.size);
    }
}