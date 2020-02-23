using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    // private List<Vihu> enemies = new List<Vihu>();
    private int enemyCountInTrigger = 0;
    public int enemiesInBaseToLose;
    void OnTriggerEnter2D(UnityEngine.Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            enemyCountInTrigger += 1;
            Debug.Log(enemyCountInTrigger + "/" + enemiesInBaseToLose + " enemies in trigger");
        } 
    }

    void OnTriggerExit2D(UnityEngine.Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            enemyCountInTrigger -= 1;
            Debug.Log(enemyCountInTrigger + "/" + enemiesInBaseToLose + " enemies in trigger");

        }
    }

    void Update()
    {
        if (enemyCountInTrigger >= enemiesInBaseToLose)
        {
            GameOver();
        }
    }


    private void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }
}
