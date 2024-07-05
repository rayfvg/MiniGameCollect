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

    // ������������� �� ������� �������� ������� � OnEnable
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

// ������������ �� ������� �������� ������� � OnDisable
private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

// ����������� ����� ��������� �������
void Rewarded(int id)
{
        // ���� ID = 1, �� ����� "+100 �����"
        if (id == 1)
            WathingADS();
}

// ����� ��� ������ ����� �������
public void  ExampleOpenRewardAd(int id)
{
    // �������� ����� �������� ����� �������
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
