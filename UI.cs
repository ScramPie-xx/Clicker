using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    void Start()
    {
        HidePanels();
    }

    void HidePanels()
    {
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "—чет: " + score;
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
