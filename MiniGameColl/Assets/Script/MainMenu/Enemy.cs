using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Level;
    public TMP_Text LvlText;

    private void Start()
    {
        LvlText.text = Level.ToString();
    }
}
