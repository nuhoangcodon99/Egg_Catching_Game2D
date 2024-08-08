using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPlayAgain : MonoBehaviour
{
    public void OnClickPlayAgain()
    {
        Time.timeScale = 1f; // Reset the time scale before reloading the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}