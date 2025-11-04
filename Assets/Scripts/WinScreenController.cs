using UnityEngine;
using UnityEngine.SceneManagement; // for scene loading
using UnityEngine.UI; // for display of winning images and sounds

public class WinScreenController : MonoBehaviour
{
    public Image winnerImage;           // UI Image component
    public Sprite playerWinSprite;      // assign in Inspector
    public Sprite computerWinSprite;    // assign in Inspector

    public AudioSource audioSource;     // attach an AudioSource component
    public AudioClip playerWinClip;     // assign in Inspector
    public AudioClip computerWinClip;   // assign in Inspector

    private void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();

        // Display winner image
        if (gm.gameWinner == GameManager.Winner.Player)
        {
            winnerImage.sprite = playerWinSprite;
            audioSource.clip = playerWinClip;
        }
        else if (gm.gameWinner == GameManager.Winner.Computer)
        {
            winnerImage.sprite = computerWinSprite;
            audioSource.clip = computerWinClip;
        }

        // Play the audio
        audioSource.Play();
    }

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
