using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Transform enemySpawnPosition;
    public Transform bonusSpawnPosition;
    public GameObject enemy;
    public GameObject bonus;
    public float enemySpawnTime = 5f;
    public float bonusSpawnTime = 7f;
    float enemyTime = 0f;
    float bonusTime = 0f;
    public Text deadText;
    public Text restartText;
    bool gameOver = false;

	void Start () {
        Instantiate(enemy, enemySpawnPosition.position, enemySpawnPosition.rotation);
	}
	
	void Update () {
        bonusTime += Time.deltaTime;
        enemyTime += Time.deltaTime;
        if (enemyTime > enemySpawnTime)
        {
            enemyTime = 0f;
            Instantiate(enemy, enemySpawnPosition.position, enemySpawnPosition.rotation);
        }

        if (bonusTime > bonusSpawnTime)
        {
            bonusTime = 0f;
            Instantiate(bonus, bonusSpawnPosition.position, bonusSpawnPosition.rotation);
        }

        if (Input.GetKey("escape"))
            Application.Quit();
        if (gameOver)
        {
            if (Input.GetKey(KeyCode.R))
                SceneManager.LoadSceneAsync(0);
        }
	}

    public void GameOver()
    {
        deadText.enabled = true;
        restartText.enabled = true;
        
        gameOver = true;
    }
}
