using UnityEngine;
using UnityEngine.SceneManagement; // for scene loading

public class WinScreenController : MonoBehaviour
{
    // Called when the "New Game" button is pressed
    public void NewGame()
    {
        SceneLoader.Instance.LoadScene("StartMenu"); // use your singleton
    }

    // Called when the "Quit" button is pressed
    public void QuitGame()
    {
        // In the editor, this won’t close play mode, but in a build it will quit
        Application.Quit();

        // Optional: log in the editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
