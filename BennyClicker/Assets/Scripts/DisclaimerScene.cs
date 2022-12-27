using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisclaimerScene : MonoBehaviour
{
    public GameObject square;

    void Awake()
    {
        int fullscreen = PlayerPrefs.GetInt("fullscreen", -1);
        int resolutionIndex = PlayerPrefs.GetInt("resolution", -1);
        Resolution[] resolutions = Screen.resolutions;
        
        if (fullscreen == 0)
            Screen.fullScreen = false;
        else if (fullscreen == 1)
            Screen.fullScreen = true;

        if (resolutionIndex != -1)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
    }

    void Start()
    {
        StartCoroutine(FadeToBlack(false));    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonUp(0))
        {
            StartCoroutine(FadeToBlack(true));
        }
    }

    IEnumerator AutoSkip()
    {
        yield return new WaitForSeconds(10f);
        StartCoroutine(FadeToBlack(true));
    }

    IEnumerator FadeToBlack(bool toBlack = true, int speed = 1)
    {
        Color objectColor = square.GetComponent<Image>().color;
        float fade;

        if (toBlack == true)
        {
            while (objectColor.a < 1)
            {
                fade = objectColor.a + (speed * Time.deltaTime);

                objectColor = new Color(0, 0, 0, fade);
                square.GetComponent<Image>().color = objectColor;
                yield return null;
            }
            SceneManager.LoadScene(1);
        }
        else
        {
            while (objectColor.a > 0)
            {
                fade = objectColor.a - (speed * Time.deltaTime);

                objectColor = new Color(0, 0, 0, fade);
                square.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
