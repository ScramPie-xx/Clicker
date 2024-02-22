using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    public GameObject squarePrefab;
    public float spawnInterval = 2f;
    public float minSize = 1f;
    public float maxSize = 3f;
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public Text scoreText;
    private int score;

    void Start()
    {
        score = 0;
        UpdateScoreText();
        InvokeRepeating("SpawnSquare", 0f, spawnInterval);
    }

    void SpawnSquare()
    {
        GameObject square = Instantiate(squarePrefab, GetRandomPosition(), Quaternion.identity);

        float size = Random.Range(minSize, maxSize);
        square.transform.localScale = new Vector3(size, size, 1f);

        float speed = Random.Range(minSpeed, maxSpeed);
        square.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
    }

    Vector2 GetRandomPosition()
    {
        float x = Random.Range(Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x,
                               Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x);
        float y = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y;

        return new Vector2(x, y);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void OnSquareClick()
    {
        IncreaseScore(10);
    }


}
