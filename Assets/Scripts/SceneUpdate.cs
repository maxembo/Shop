using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUpdate : MonoBehaviour
{
    public void UpdateScene(string name) => SceneManager.LoadScene(name);
}
