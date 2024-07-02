using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RandomPosGame4 : MonoBehaviour
{
    public GameObject pos1;
    public GameObject pos2;

    public Button tap;

    public void RandomPosTap()
    {
        pos1.transform.position = new Vector3(5.1f, Random.Range(2f, -2f), 0);
        pos2.transform.position = new Vector3(-5.09f, Random.Range(2f, -2f), 0);  
    }

   
}
