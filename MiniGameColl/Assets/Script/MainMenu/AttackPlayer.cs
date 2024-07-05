using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackPlayer : MonoBehaviour
{
    public Enemy[] enemies;
    public int _index;

    public AudioSource _AttackSound;

    public int[] LevelsEnemy;


    private int LevelPlayer;
    public TMP_Text textlvl;

    public GameObject EndGameScene;


    private void Awake()
    {
        _index = PlayerPrefs.GetInt("index");
        if (_index > 0)
            transform.position = enemies[_index - 1].transform.position; //переместил л€гуху
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
        if (_index != 7)
        {
            if (LevelPlayer >= LevelsEnemy[_index])
            {
                _AttackSound.Play();
                transform.position = enemies[_index].transform.position;
                enemies[_index].gameObject.SetActive(false);
                _index++;
                PlayerPrefs.SetInt("index", _index);    
            }
        }
        else
        {
            GameEnd();
        }

    }

    public void GameEnd()
    {
        EndGameScene.SetActive(true);
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }



}
