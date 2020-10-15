using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject OptionsMenu = null;
    public GameObject MainMenu = null;
    public GameObject ControlsMenu = null;
    public void PlayButton()
    {
        SceneManager.LoadScene("SceneOne(GAME)");
    }

    public void OptionsButton()
    {
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);

    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        ControlsMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
            
    }
    public void ControlsButton()
    {
        MainMenu.SetActive(false);
        ControlsMenu.SetActive(true);
    }

}
