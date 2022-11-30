using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public GameObject pipes = null;
    public GameObject gameOverScreen = null;
    Rigidbody2D rb2D;
    float birdSpeed = 4f;
    int pipeCount = 1;
    float score;
    public Text scoreText = null;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = Vector2.up * birdSpeed;
        }
        if (pipeCount < 2)
        {
            StartCoroutine(PipeSpawn());
        }
        scoreText.text = score.ToString();
    }
    IEnumerator PipeSpawn()
    {
        for (int i = 0; i < pipeCount; i++)
        {
            Instantiate(pipes, new Vector2(6, Random.Range(-3, 2)), Quaternion.identity);
            pipeCount++;
            yield return new WaitForSeconds(3);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            Destroy(gameObject);
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else if(collision.tag == "Pipe")
        {
            Destroy(gameObject);
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else if(collision.tag == "ScorePoint")
        {
            score++;
        }
    }
}
