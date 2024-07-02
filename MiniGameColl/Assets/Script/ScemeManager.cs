using UnityEngine;
using UnityEngine.SceneManagement;

public class ScemeManager : MonoBehaviour
{
    public void SwitchScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public void ResetAllSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
