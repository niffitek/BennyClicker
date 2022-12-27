using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTextSwitch : MonoBehaviour
{
    public GameObject game;
    public GameObject victoryText;
    private bool isVictory = false;
    public void showText()
    {
        isVictory = true;
        game.SetActive(false);
        victoryText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isVictory)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
            {
                isVictory = false;
                game.SetActive(true);
                victoryText.SetActive(false);
            }
        }
    }
}
