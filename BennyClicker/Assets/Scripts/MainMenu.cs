using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject creditsMenu;
    public GameObject confirmMenu;
    public GameObject FadeImage;

    public AudioMixer audioMixer;

    void Start()
    {
        StartCoroutine(FadeToClear());
        float volume = PlayerPrefs.GetFloat("volume", -1);

        if (volume != -1)
            audioMixer.SetFloat("volume", volume);
    }

    IEnumerator FadeToClear()
    {
        Color objectColor = FadeImage.GetComponent<Image>().color;
        float fade;

        while (objectColor.a > 0)
        {
            fade = objectColor.a - (2 * Time.deltaTime);

            objectColor = new Color(0, 0, 0, fade);
            FadeImage.GetComponent<Image>().color = objectColor;
            yield return null;
        }
        FadeImage.SetActive(false);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("new", 1);
        SceneManager.LoadScene(2);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("new", 0);
        SceneManager.LoadScene(2);
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void CloseCredits()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void OpenConfirm()
    {
        mainMenu.SetActive(false);
        confirmMenu.SetActive(true);
    }

    public void CloseConfirm()
    {
        confirmMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
