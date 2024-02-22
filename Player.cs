using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int score;
    private GameObject[] squares;

    void Start()
    {
        squares = GameObject.FindGameObjectsWithTag("Square");
        score = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }

        if (score >= 100)
        {
            Victory();
        }
    }

    void CheckClick()
    {
        foreach (GameObject square in squares)
        {
            if (square.activeSelf && IsClickedOnSquare(square))
            {
                IncreaseScore(10);
                return;
            }
        }
    }

    bool IsClickedOnSquare(GameObject square)
    {
        Collider2D squareCollider = square.GetComponent<Collider2D>();
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return squareCollider.bounds.Contains(mousePosition);
    }

    public void IncreaseScore(int points)
    {
        score += points;
    }

    void Victory()
    {
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}