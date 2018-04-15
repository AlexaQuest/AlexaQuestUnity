using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController MainGameController;
    public PlayerController Player;

    GameController()
    {
        MainGameController = this;
    }

    public bool PlayerTurn = true;

    public List<EnemyController> Enemies;

    public void GameOver()
    {
        Player.GetComponent<ParticleSystem>().Play();
        StartCoroutine(EndOfLife());
    }

    IEnumerator EndOfLife()
    {
        APIConnector.ApiConnector.GameOver();
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}