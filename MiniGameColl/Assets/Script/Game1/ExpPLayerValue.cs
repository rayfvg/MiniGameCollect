using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpPLayerValue : MonoBehaviour
{
    public float ExpPLayer;
    public int Level;

    public Slider sliderExp;

    public TMP_Text textLvl;
    public TMP_Text textExp;

    private void Start()
    {
        sliderExp.value = PlayerPrefs.GetFloat("exp");
        ExpPLayer = PlayerPrefs.GetFloat("exp");
        Level = PlayerPrefs.GetInt("lvl");
        TextUpdate();

    }
    public void AddExpValue(float value)
    {
        ExpPLayer += value;
        UpdateValueSlader();
        PlayerPrefs.SetFloat("exp", ExpPLayer);
        if (ExpPLayer >= 10)
        {
            ExpPLayer = 0;
            PlayerPrefs.SetFloat("exp", ExpPLayer);
            UpdateValueSlader();
            Level += 1;
            PlayerPrefs.SetInt("lvl", Level);
        }
        TextUpdate();
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
