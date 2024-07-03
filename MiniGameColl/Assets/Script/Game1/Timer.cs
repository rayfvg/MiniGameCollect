using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text TextTimer;

    public int GamerTimerOver = 30;
    public GameObject gameOverLable;

    public GameObject Player;
    public GameObject Spawner;
    

    //private void Update()
    //{
    //    GamerTimerOver -= Time.deltaTime;
    //    TextTimer.text = GamerTimerOver.ToString();
    //    if (GamerTimerOver <= 0)
    //    {
    //        GameOver();
    //    }
    //}

    void Start()
    {
        StartCoroutine("LoseTime");
        UpdateCountdownText();
    }

    IEnumerator LoseTime()
    {
        while (GamerTimerOver > 0)
        {
            yield return new WaitForSeconds(1);
            GamerTimerOver--;
            UpdateCountdownText();
        }
        GameOver();
    }

    void UpdateCountdownText()
    {
        TextTimer.text = GamerTimerOver.ToString();
    }




    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverLable.SetActive(true);
        Player.SetActive(false);
        Spawner.SetActive(false);
       
    }
}
