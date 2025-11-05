using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Ball ball;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI computerScoreText;
    public Paddle playerPaddle;
    public Paddle computerPaddle;

    [SerializeField] private int _playerScore;
    [SerializeField] private int _computerScore;
    public int WinScore = 5;

    public enum Winner { None, Player, Computer }
    public Winner gameWinner = Winner.None;

    // Read-only properties
    public int PlayerScore => _playerScore;
    public int ComputerScore => _computerScore;

    public void PlayerScores()
    {
        _playerScore++;
        this.playerScoreText.text = _playerScore.ToString();
        if (!CheckWinCondition()) // returns true if game is won 
        {
            ResetRound();
        }
    }
    public void ComputerScores()
    {
        _computerScore++;
        this.computerScoreText.text = _computerScore.ToString();
        if (!CheckWinCondition()) // returns true if game is won 
        {
            ResetRound();
        }
    }

    private void ResetRound()
    {
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
        this.playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();
    }

    [SerializeField]
    private bool CheckWinCondition()
    {
        if (_playerScore >= WinScore)
        {
            gameWinner = Winner.Player;
            SceneLoader.Instance.LoadScene("WinScreen");
            return true; // game over
        }
        else if (_computerScore >= WinScore)
        {
            gameWinner = Winner.Computer;
            SceneLoader.Instance.LoadScene("WinScreen");
            return true; // game over
        }

        return false; // game continues
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
