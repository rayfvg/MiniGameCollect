using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class adsForClick : MonoBehaviour
{
   
    public GameObject Taked;
    public GameObject ads;

    private void Start()
    {
        if (PlayerPrefs.GetInt("bonus") == 2)
        {
            WathingADS();
        }
    }

    // Подписываемся на событие открытия рекламы в OnEnable
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

// Отписываемся от события открытия рекламы в OnDisable
private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

// Подписанный метод получения награды
void Rewarded(int id)
{
        // Если ID = 1, то выдаём "+100 монет"
        if (id == 1)
            WathingADS();
}

// Метод для вызова видео рекламы
public void  ExampleOpenRewardAd(int id)
{
    // Вызываем метод открытия видео рекламы
    YandexGame.RewVideoShow(id);
}
    void WathingADS()
    {
        PlayerPrefs.SetInt("bonus", 2);
        Taked.SetActive(true);
        ads.SetActive(false);
        gameObject.GetComponent<Button>().enabled = false;
    }
    
}
