using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public interface IController
{
    void AddScore(int newScoreValue);
    void AddLife(int newLifeValue);
    void GameOver();
    int GetLife();
}

public class GameController : MonoBehaviour, IController
{
    public GameObject hazard;
    public GameObject player;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;
    public Text LifeText;
    public int Score;
    public int Life = 3;

    bool gameOver;
    bool Restart;

    void Start()
    {
        Score = 0;
        UpdateScore();
        UpdateLife();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (Restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                RestartText.text = "Press 'R' for restart";
                Restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        Score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {

        ScoreText.text = "Score: " + Score;
    }

    public void AddLife(int newLifeValue)
    {
        Life -= newLifeValue;
        UpdateLife();
    }

    void UpdateLife()
    {

        LifeText.text = "Life x" + Life;
    }

    public int GetLife()
    {
        return Life;
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;
    }
}