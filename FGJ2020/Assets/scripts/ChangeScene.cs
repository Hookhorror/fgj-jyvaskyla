using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void OpenStartScreen()
    {
        Debug.Log("StartingScreen button clicked");
        SceneManager.LoadScene("StartingScreen");
    }
    public void OpenCredits()
    {
        Debug.Log("Credits clicked");
        SceneManager.LoadScene("Credits");
    }

    public void OpenLevel1()
    {
        Debug.Log("StartGame clicked");
        SceneManager.LoadScene("lopullinen_kentta");
    }
}