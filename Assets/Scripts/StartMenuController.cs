using UnityEngine;
using TMPro;

public class StartMenuController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown difficultyDropdown;

    private void Start()
    {
        difficultyDropdown.onValueChanged.AddListener(SetDifficulty);
    }

    private void SetDifficulty(int index)
    {
        if (GameManager.Instance == null) return;
        // Tell the GameManager which difficulty to use
        switch (index)
        {
            case 0:
                GameManager.Instance.SetDifficulty(GameManager.Difficulty.Easy);
                break;
            case 1:
                GameManager.Instance.SetDifficulty(GameManager.Difficulty.Medium);
                break;
            case 2:
                GameManager.Instance.SetDifficulty(GameManager.Difficulty.Hard);
                break;
        }
    }

    public void StartGame()
    {
        SceneLoader.Instance.LoadScene("MainGame");
    }
}