using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour
{
    public void _LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void _LoadStoredScene()
    {
        NavigationManager.NavigateTo(Destination.instance.loadDestination);
    }
}
