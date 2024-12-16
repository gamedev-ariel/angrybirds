using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int currentLevelIndex = 0;

    private void Awake()
    {
        // Singleton pattern to ensure one instance of GameManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist through scenes
        }
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log(currentLevelIndex.ToString());
            SceneManager.LoadScene(currentLevelIndex);
        }
        else
        {
            Debug.Log("Game Over! All levels completed.");
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int levelIndex)
    {
        currentLevelIndex = levelIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }
}