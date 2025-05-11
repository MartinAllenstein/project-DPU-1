using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtom : MonoBehaviour
{
    public void OnPressStartButtom()
    {
        SceneManager.LoadScene("GameScene");
    }
}
