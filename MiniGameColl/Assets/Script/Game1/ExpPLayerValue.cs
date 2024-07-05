using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpPLayerValue : MonoBehaviour
{
    public float ExpPLayer;
    public int Level;
    private int _bonus;

    public Slider sliderExp;

    public TMP_Text textLvl;
    public TMP_Text textExp;

    public AudioSource _takeSound;

    private void Start()
    {
        _bonus = PlayerPrefs.GetInt("bonus");
        sliderExp.value = PlayerPrefs.GetFloat("exp");
        ExpPLayer = PlayerPrefs.GetFloat("exp");
        Level = PlayerPrefs.GetInt("lvl");
        TextUpdate();

    }
    public void AddExpValue(float value)
    {
        if (_bonus == 2)
        {
        ExpPLayer = ExpPLayer + value * _bonus;
            
        }
        else
        {
            ExpPLayer = ExpPLayer + value;
            
        }

        PlayerPrefs.SetFloat("exp", ExpPLayer);
        UpdateValueSlader();
        if (ExpPLayer >= 10)
        {
            ExpPLayer = 0;
            PlayerPrefs.SetFloat("exp", ExpPLayer);
            UpdateValueSlader();
            Level += 1;
            PlayerPrefs.SetInt("lvl", Level);
        }
        TextUpdate();
        _takeSound.Play();
    }

    public void TextUpdate()
    {
       textExp.text = PlayerPrefs.GetFloat("exp").ToString();
       textLvl.text = PlayerPrefs.GetInt("lvl").ToString();
    }

    public void UpdateValueSlader()
    {
        sliderExp.value = PlayerPrefs.GetFloat("exp");
    }
}
