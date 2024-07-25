using UnityEngine;

namespace Common
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _speed;

        private float _currentRotation;

        private void Update()
        {
            _currentRotation -= Time.deltaTime * _speed;
            transform.rotation = Quaternion.Euler(0, _currentRotation, 0);
        }

        public void ResetRotation() => _currentRotation = 0;
    }
}