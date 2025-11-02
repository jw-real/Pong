using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    // This is called by the button
    public void StartGame()
    {
        // Call the singleton SceneLoader to load MainGame
        SceneLoader.Instance.LoadScene("MainGame");
    }
}
