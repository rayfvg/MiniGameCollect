using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject[] GameObjects;
    
    
   
    public void StartingMenu()
    {
        Time.timeScale = 1.0f;
        for (int i = 0; i < GameObjects.Length; i++)
        {
            GameObjects[i].SetActive(true);
        }
    }
}
