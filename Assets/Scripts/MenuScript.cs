using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("PlayGame");
        HealthTextScript.Health = 10;
        AmmoTextScript.Ammo = 0;
        ScoreTextScript.Score = 0;
        CoinTextScript.Coins = 0;
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
