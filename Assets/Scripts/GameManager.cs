using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("References")]    
    public Ball ball;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI computerScoreText;
    public Paddle playerPaddle;
    public Paddle computerPaddle;
    [Space(10)]

    [Header("Difficulty Settings")]
    [SerializeField] private float easyPaddleSpeed = 5f;
    [SerializeField] private float mediumPaddleSpeed = 8f;
    [SerializeField] private float hardPaddleSpeed = 12f;
    private float currentPaddleSpeed;
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty currentDifficulty;
    [Space(10)]

    [Header("Game Settings")]
    [SerializeField] private int _playerScore;
    [SerializeField] private int _computerScore;
    public int WinScore = 5;
    [Space(10)]

    [Header("State")]
    public Winner gameWinner = Winner.None;
    public enum Winner { None, Player, Computer }
    

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
    
    public void SetDifficulty(Difficulty difficulty)
{
    currentDifficulty = difficulty;
}

// Call this from MainGame scene when paddles load
    public void ApplyDifficulty()
    {
        switch (currentDifficulty)
        {
            case Difficulty.Easy:
                computerPaddle.speed = easyPaddleSpeed;
                break;
            case Difficulty.Medium:
                computerPaddle.speed = mediumPaddleSpeed;
                break;
            case Difficulty.Hard:
                computerPaddle.speed = hardPaddleSpeed;
                break;
        }
    }

    public float GetCurrentPaddleSpeed()
    {
        return currentPaddleSpeed;
    }

    private void Awake()
    {
        ApplyDifficulty();
        
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
