using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdaterText : MonoBehaviour
{
    public ExpPLayerValue Players;


    private void Awake()
    {
        Players.UpdateValueSlader();
        Players.TextUpdate();
    }
}
