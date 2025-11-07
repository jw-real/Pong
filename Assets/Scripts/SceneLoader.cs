using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public Difficulty SelectedDifficulty { get; private set; } = Difficulty.Normal;

    public void SetDifficulty(Difficulty difficulty)
    {
        SelectedDifficulty = difficulty;
    }

}
