using Common;
using UnityEngine;

public class SkinPlacement : MonoBehaviour
{
    private const string RenderLayer = "SkinRender";
    
    [SerializeField] private Rotator _rotator;

    private GameObject _currentModel;

    public void InstaniateModel(GameObject model)
    {
        if(_currentModel != null) Destroy(_currentModel.gameObject);
        
        _rotator.ResetRotation();
        
        _currentModel = Instantiate(model, transform);
        
        Transform[] childrens = _currentModel.GetComponentsInChildren<Transform>();
        
        foreach (var child in childrens)
            child.gameObject.layer = LayerMask.NameToLayer(RenderLayer);
    }

}