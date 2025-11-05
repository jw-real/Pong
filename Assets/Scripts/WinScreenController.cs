using UnityEngine;
using UnityEngine.SceneManagement; // for scene loading
using UnityEngine.UI; // for display of winning images and sounds
using TMPro;

public class WinScreenController : MonoBehaviour
{
    [SerializeField] private Image winnerImage;           // UI Image component
    [SerializeField] private Sprite playerWinSprite;      // assign in Inspector
    [SerializeField] private Sprite computerWinSprite;    // assign in Inspector
    [SerializeField] private AudioSource audioSource;     // attach an AudioSource component
    [SerializeField] private AudioClip playerWinClip;     // assign in Inspector
    [SerializeField] private AudioClip computerWinClip;   // assign in Inspector
    [SerializeField] private TextMeshProUGUI resultText;

    private void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        resultText.text = $"Player {gm.PlayerScore} - Computer {gm.ComputerScore}\n";

        // Display winner image
        if (gm.gameWinner == GameManager.Winner.Player)
        {
            winnerImage.sprite = playerWinSprite;
            audioSource.clip = playerWinClip;
            resultText.text += "Player Wins!";
        }
        else if (gm.gameWinner == GameManager.Winner.Computer)
        {
            winnerImage.sprite = computerWinSprite;
            audioSource.clip = computerWinClip;
            resultText.text += "Computer Wins!";
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
