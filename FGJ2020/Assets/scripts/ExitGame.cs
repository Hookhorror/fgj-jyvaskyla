using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Exit button pressed");
        Application.Quit();
    }
}
