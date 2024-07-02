using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public Enemy[] enemies;
    private int _index;

    public int[] LevelsEnemy;


    private int LevelPlayer;

    public TMP_Text textlvl;




    private void Start()
    {
        LevelPlayer = PlayerPrefs.GetInt("lvl");
        textlvl.text = LevelPlayer.ToString();
    }


    public void TryAttackEnemy()
    {
        if (LevelPlayer >= LevelsEnemy[_index])
        {
            transform.position = enemies[_index].transform.position;
            enemies[_index].gameObject.SetActive(false);
            _index++;
        }
        else
        {
            print("Ќе достаточный уровень, нужно еще  " + (LevelsEnemy[_index] - LevelPlayer) + " уровней");
        }
    }





}
