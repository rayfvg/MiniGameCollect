using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text TextTimer;

    public float GamerTimerOver = 30f;
    public GameObject gameOverLable;

    public GameObject Player;
    public GameObject Spawner;
    

    private void Update()
    {
        GamerTimerOver -= Time.deltaTime;
        TextTimer.text = GamerTimerOver.ToString();
        if (GamerTimerOver <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverLable.SetActive(true);
        Player.SetActive(false);
        Spawner.SetActive(false);
       
    }
}
