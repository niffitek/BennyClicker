using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnitType;
using UpgradeClass;

public class ScoreHandler : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text perClickText;
    public TMP_Text perSecondText;
    public GameObject pedigree;
    int pedigreeSprite = 1;
    public unitInt score = new unitInt(0, 0);
    public unitInt upgradeIncrease = new unitInt(0, 0);
    public unitInt clickIncrease = new unitInt(1, 0);

    public UpgradeHandler upgradeHandler;
    
    IEnumerator Start()
    {
        int i = 0;

        if (PlayerPrefs.GetInt("new") == 0)
            loadScore();
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score.Add(upgradeIncrease);
            if (i == 5)
            {
                SaveAndLoad.Save(this, upgradeHandler);
                i = 0;
            }
            i += 1;
        }
    }

    void Update()
    {
        scoreText.SetText(score.toString() + " Leckerlies");
        perClickText.SetText(clickIncrease.toString() + " Leckerlies / Click");
        perSecondText.SetText(upgradeIncrease.toString() + " Leckerlies / Second");
    }

    public void IncreaseScoreClick()
    {
        score.Add(clickIncrease);
    }

    public void loadScore()
    {
        GameData data = SaveAndLoad.Load();

        if (data == null)
        {
            return;
        }

        score.Value = data.scoreValue;
        score.Unit = data.scoreUnit;

        clickIncrease.Value = data.clickIncreaseValue;
        clickIncrease.Unit = data.clickIncreaseUnit;

        upgradeIncrease.Value = data.upgradeIncreaseValue;
        upgradeIncrease.Unit = data.upgradeIncreaseUnit;
    }
}
