using UnityEngine;

public class CameraPositionUpdater : MonoBehaviour
{
    [SerializeField] private Camera _modelCamera;
    [field: SerializeField] public Transform CharacterCategoryCameraPosition { get; private set; }
    [field: SerializeField] public Transform MazeCategoryCameraPosition { get; private set; }

    public void UpdateCameraPosition(Transform transform)
    {
        _modelCamera.transform.position = transform.position;
        _modelCamera.transform.rotation = transform.rotation;
    }
}