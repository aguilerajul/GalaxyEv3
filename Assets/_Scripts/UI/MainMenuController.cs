using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame(AudioClip buttonClip)
    {
        AudioSource.PlayClipAtPoint(buttonClip, this.transform.position, 1f);
        SceneManager.LoadScene(1);
    }

    public void CreditsGame(AudioClip buttonClip)
    {
        AudioSource.PlayClipAtPoint(buttonClip, this.transform.position, 1f);
        SceneManager.LoadScene(2);
    }

    public void QuitGame(AudioClip buttonClip)
    {
        AudioSource.PlayClipAtPoint(buttonClip, this.transform.position, 1f);
        Application.Quit();
    }
}
