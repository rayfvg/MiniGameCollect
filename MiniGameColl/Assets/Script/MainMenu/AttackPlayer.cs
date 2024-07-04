using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackPlayer : MonoBehaviour
{
    public Enemy[] enemies;
    public int _index;
    

    public int[] LevelsEnemy;


    private int LevelPlayer;
    public TMP_Text textlvl;

    public GameObject EndGameScene;


    private void Awake()
    {
        _index = PlayerPrefs.GetInt("index");
        if(_index > 0)
        transform.position = enemies[_index - 1].transform.position; //переместил лягуху
        for (int i = 0; i < _index; i++)
        {
            enemies[i].gameObject.SetActive(false);
        }
        


    }

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
            PlayerPrefs.SetInt("index", _index);
            if (_index == 6)
            {
                GameEnd();
            }
        }
        else
        {
            print("Не достаточный уровень, нужно еще  " + (LevelsEnemy[_index] - LevelPlayer) + " уровней");
        }
    }

    public void GameEnd()
    {
        EndGameScene.SetActive(true);
    }
    public void ResetGame()
    {
        PlayerPrefs.SetInt("index", 0);
        SceneManager.LoadScene(0);
    }



}
