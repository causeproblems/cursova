using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)
        UnityEditor.EditorApplication.isPlaying = false;

    }

}