using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnitType;
using UpgradeClass;
using System;

public class UpgradeHandler : MonoBehaviour
{
    public VictoryTextSwitch victory;
    public GameObject contentPrefab;
    public GameObject scrollViewContent;
    public GameObject errorMessage;
    public ScoreHandler scoreHandler;
    GameObject[] arrayObject = new GameObject[100];
    public Upgrade[] arrayData;

    private bool isVictory = true;

    void Awake()
    {
        if (PlayerPrefs.GetInt("new") == 1)
            initStructure();
        else
            loadStructure();
    }

    void Start()
    {
        scrollViewContent.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollViewContent.GetComponent<RectTransform>().sizeDelta.x, arrayData.Length * 160 + 20);

        for (int i = 0; i < arrayData.Length; i += 1)
        { 
            GameObject content = Instantiate(contentPrefab, new Vector3(1000, -i * 160 - 20, 0), Quaternion.identity);
            content.transform.parent = scrollViewContent.transform;
            content.transform.localScale = new Vector3(1, 1, 0);
            fillContent(content, i, arrayData[i]);
            arrayObject[i] = content;
        }    
    }

    void loadStructure()
    {
        GameData data = SaveAndLoad.Load();

        if (data == null)
        {
            initStructure();
            return;
        }

        int len = data.names.Length;
        arrayData = new Upgrade[len];

        for (int i = 0; i < len; i += 1)
        {
            arrayData[i] = new Upgrade(data.spritePaths[i], data.names[i], data.isClickIncreases[i], new unitInt(data.numberValues[i], data.numberUnits[i]), new unitInt(data.priceValues[i], data.priceUnits[i]), new unitInt(data.increaseValues[i], data.increaseUnits[i]));
        }
    }

    void initStructure()
    {
        arrayData = new Upgrade[] {
            new Upgrade("Upgrades/bennyg187", "OG 187 Gang", true, new unitInt(0, 0), new unitInt(35, 0), new unitInt(20, 0)),
            new Upgrade("Upgrades/bennygClowniking", "Clowniking", false, new unitInt(0, 0), new unitInt(1.6, 1), new unitInt(3, 1)),
            new Upgrade("Upgrades/bennygFedup", "Fedup", false, new unitInt(0, 0), new unitInt(2.7, 2), new unitInt(3, 2)),
            new Upgrade("Upgrades/bennygSexy", "Seppirott", true, new unitInt(0, 0), new unitInt(3.6, 3), new unitInt(3, 3)),
            new Upgrade("Upgrades/bennygSad", "Sadge", false, new unitInt(0, 0), new unitInt(4.8, 4), new unitInt(3, 4)),
            new Upgrade("Upgrades/bennygS", "Drip Swerve", false, new unitInt(0, 0), new unitInt(5.1, 5), new unitInt(3, 5)),

            new Upgrade("Upgrades/bennygKickflip", "Kickflip", true, new unitInt(0, 0), new unitInt(6.9, 6), new unitInt(2, 6)),
            new Upgrade("Upgrades/bennygZeit", "Phantom Hourglass", false, new unitInt(0, 0), new unitInt(7.4, 7), new unitInt(2, 7)),
            new Upgrade("Upgrades/bennygOmegaxd", "HAHAHA", false, new unitInt(0, 0), new unitInt(8.8, 8), new unitInt(2, 8)),
            new Upgrade("Upgrades/bennygMM", "MHM ~ Yung Hurn", true, new unitInt(0, 0), new unitInt(9.2, 9), new unitInt(2, 9)),
            new Upgrade("Upgrades/bennygLike", "LikeLikeLike", false, new unitInt(0, 0), new unitInt(10.1, 10), new unitInt(2, 10)),
            new Upgrade("Upgrades/bennygKek", "So ein kek", false, new unitInt(0, 0), new unitInt(11.3, 11), new unitInt(2, 11)),

            new Upgrade("Upgrades/bennygGuna", "Guna <3", true, new unitInt(0, 0), new unitInt(12.7, 12), new unitInt(2, 12)),
            new Upgrade("Upgrades/bennygHifi", "High Five!", false, new unitInt(0, 0), new unitInt(13.9, 13), new unitInt(1, 13)),
            new Upgrade("Upgrades/bennygHaha", "Hehe", false, new unitInt(0, 0), new unitInt(14.1, 14), new unitInt(1, 14)),
            new Upgrade("Upgrades/bennygEhhwas", "Moneyboy kinq?", true, new unitInt(0, 0), new unitInt(15.5, 15), new unitInt(2, 15)),
            new Upgrade("Upgrades/bennygBaby", "Jaa Baby Yodi", false, new unitInt(0, 0), new unitInt(16.4, 16), new unitInt(1, 16)),
            new Upgrade("Upgrades/bennygIchHasseDich", "Go to...", false, new unitInt(0, 0), new unitInt(17.7, 17), new unitInt(1, 17)),

            new Upgrade("Upgrades/bennygBonkhammer", "...Hornyjail", true, new unitInt(0, 0), new unitInt(18.6, 18), new unitInt(2, 18)),
            new Upgrade("Upgrades/bennygCringe", "Criiiiinge", false, new unitInt(0, 0), new unitInt(19.8, 19), new unitInt(900, 18)),
            new Upgrade("Upgrades/bennygInk", "Oktopu$$y", false, new unitInt(0, 0), new unitInt(20.5, 20), new unitInt(900, 19)),
            new Upgrade("Upgrades/bennygSSd", "SSD!!!", true, new unitInt(0, 0), new unitInt(21.8, 21), new unitInt(2, 21)),
            new Upgrade("Upgrades/bennygYep", "Hundeblick UwU", false, new unitInt(0, 0), new unitInt(22.1, 22), new unitInt(900, 21)),
            new Upgrade("Upgrades/bennygSpiderman", "Spideyyy", false, new unitInt(0, 0), new unitInt(23.2, 23), new unitInt(900, 22)),

            new Upgrade("Upgrades/bennygCringemond", "Cringemond", true, new unitInt(0, 0), new unitInt(24.4, 24), new unitInt(2, 24)),
            new Upgrade("Upgrades/bennygPray", "Bitte, bitte...", false, new unitInt(0, 0), new unitInt(25.2, 25), new unitInt(800, 24)),
            new Upgrade("Upgrades/bennygPisse", "Pissekink UwU", false, new unitInt(0, 0), new unitInt(26.9, 26), new unitInt(800, 25)),
            new Upgrade("Upgrades/bennygWallE", "RoboBenny", true, new unitInt(0, 0), new unitInt(27.6, 27), new unitInt(2, 27)),
            new Upgrade("Upgrades/bennygShlime", "Slime ich balle harder", false, new unitInt(0, 0), new unitInt(28.4, 28), new unitInt(800, 27)),
            new Upgrade("Upgrades/bennygEsistwiederkalt", "Alle zudecken", false, new unitInt(0, 0), new unitInt(29.2, 29), new unitInt(800, 28)),

            new Upgrade("Upgrades/bennygKannWerReden", "Benny staenkert", true, new unitInt(0, 0), new unitInt(30.8, 30), new unitInt(2, 30)),
            new Upgrade("Upgrades/bennygOmg", "bennygOmg", false, new unitInt(0, 0), new unitInt(31.6, 31), new unitInt(700, 30)),
            new Upgrade("Upgrades/bennygKingflip", "Kinqflip", false, new unitInt(0, 0), new unitInt(32.4, 32), new unitInt(700, 31)),
            new Upgrade("Upgrades/bennygYuwuma", "Yuwuma Sticker Jaa", true, new unitInt(0, 0), new unitInt(33.5, 33), new unitInt(2, 33)),
            new Upgrade("Upgrades/bennygGeld", "Stonks", false, new unitInt(0, 0), new unitInt(34.9, 34), new unitInt(700, 33)),
            new Upgrade("Upgrades/bennygHadili", "Danke Benny", false, new unitInt(0, 0), new unitInt(35, 35), new unitInt(1, 35)),
        };
    }

    void fillContent(GameObject content, int i, Upgrade data)
    {
        GameObject Icon = content.transform.GetChild(0).gameObject;
        GameObject Name = content.transform.GetChild(1).gameObject;
        GameObject Description = content.transform.GetChild(2).gameObject;
        GameObject Number = content.transform.GetChild(3).gameObject;
        GameObject BuyButton = content.transform.GetChild(4).gameObject;
        GameObject BuyButtonText = BuyButton.transform.GetChild(0).gameObject;

        var contentSprite = Resources.Load<Sprite>(data.SpritePath) as Sprite;
        Icon.GetComponent<Image>().sprite = contentSprite;

        if (data.Number.Value > 0 || data.Number.Unit > 0)
        {
            Name.GetComponent<TMP_Text>().SetText(data.Name);

            if (data.IsClickIncrease)
                Description.GetComponent<TMP_Text>().SetText("+ " + data.Increase.toString() + " Leckerlies / Click");
            else
                Description.GetComponent<TMP_Text>().SetText("+ " + data.Increase.toString() + " Leckerlies / Second");

            Number.GetComponent<TMP_Text>().SetText("x " + data.Number.toString());
        }
        else
        {
            Icon.GetComponent<Image>().color = new Color32(0, 0, 0, 225);

            Name.GetComponent<TMP_Text>().SetText("???");

            Description.GetComponent<TMP_Text>().SetText("? ? ?");

            Number.GetComponent<TMP_Text>().SetText("x 0");
        }

        BuyButtonText.GetComponent<TMP_Text>().SetText(data.Price.toString());
        BuyButton.GetComponent<Button>().onClick.AddListener(delegate { buyUpgrade(i); });
    }

    void Unlock(GameObject content, Upgrade data)
    {
        GameObject Icon = content.transform.GetChild(0).gameObject;
        GameObject Name = content.transform.GetChild(1).gameObject;
        GameObject Description = content.transform.GetChild(2).gameObject;

        Icon.GetComponent<Image>().color = new Color32(225, 225, 225, 225);

        Name.GetComponent<TMP_Text>().SetText(data.Name);

        if (data.IsClickIncrease)
            Description.GetComponent<TMP_Text>().SetText("+ " + data.Increase.toString() + " Leckerlies / Click\n" +
                "Next: + " + data.Increase.ToString() + " Leckerlies / Click");
        else
            Description.GetComponent<TMP_Text>().SetText("+ " + data.Increase.toString() + " Leckerlies / Second\n" +
                "Next: + " + data.Increase.ToString() + " Leckerlies / Second");
    }

    void updateContent(GameObject content, int i, Upgrade data)
    {
        GameObject Description = content.transform.GetChild(2).gameObject;
        GameObject Number = content.transform.GetChild(3).gameObject;
        GameObject BuyButton = content.transform.GetChild(4).gameObject;
        GameObject BuyButtonText = BuyButton.transform.GetChild(0).gameObject;


        if (data.IsClickIncrease)
            Description.GetComponent<TMP_Text>().SetText("+ " + data.Increase.toString() + " Leckerlies / Click");
        else
            Description.GetComponent<TMP_Text>().SetText("+ " + data.Increase.toString() + " Leckerlies / Second");

        Number.GetComponent<TMP_Text>().SetText("x " + data.Number.toString());

        BuyButtonText.GetComponent<TMP_Text>().SetText(data.Price.toString());

    }

    void increaseSecondInc(Upgrade item)
    {
        unitInt add = new unitInt(0.06f * item.Number.Value * item.Increase.Value, item.Increase.Unit);
        item.Increase.Add(add);
    }

    void increaseClickInc(Upgrade item)
    {
        unitInt add = new unitInt(0.12f * item.Number.Value * item.Increase.Value, item.Increase.Unit);
        item.Increase.Add(add);
    }

    void increaseClickPrice(Upgrade item)
    {
        unitInt add = new unitInt(0.15f * item.Number.Value * item.Price.Value, item.Price.Unit);
        item.Price.Add(add);
    }
    void increaseSecondPrice(Upgrade item)
    {
        unitInt add = new unitInt(0.2f * item.Number.Value * item.Price.Value, item.Price.Unit);
        item.Price.Add(add);
    }

    void updateScoreHandler(bool isClickIncrease)
    {
        if (isClickIncrease)
        {
            scoreHandler.clickIncrease = new unitInt(0, 0);
            foreach (Upgrade item in arrayData)
            {
                if (item.IsClickIncrease && (item.Number.Value > 0 || item.Number.Unit > 0))
                    scoreHandler.clickIncrease.Add(item.Increase);
            }
        }
        else
        {
            scoreHandler.upgradeIncrease = new unitInt(0, 0);
            foreach (Upgrade item in arrayData)
            {
                if (!item.IsClickIncrease && (item.Number.Value > 0 || item.Number.Unit > 0))
                    scoreHandler.upgradeIncrease.Add(item.Increase);
            }
        }
    }

    void buyUpgrade(int i)
    {
        if (scoreHandler.score.Unit > arrayData[i].Price.Unit || (scoreHandler.score.Unit == arrayData[i].Price.Unit && scoreHandler.score.Value >= arrayData[i].Price.Value))
        {
            if (arrayData[i].Number.Value == 0 && arrayData[i].Number.Unit == 0)
                Unlock(arrayObject[i], arrayData[i]);
            scoreHandler.score.Sub(arrayData[i].Price);

            arrayData[i].Number.Add(new unitInt(1, 0));

            if (arrayData[i].IsClickIncrease)
            {
                increaseClickInc(arrayData[i]);
                increaseClickPrice(arrayData[i]);

            }
            else
            {
                increaseSecondInc(arrayData[i]);
                increaseSecondPrice(arrayData[i]);
            }
            updateScoreHandler(arrayData[i].IsClickIncrease);

            updateContent(arrayObject[i], i, arrayData[i]);
            SaveAndLoad.Save(scoreHandler, this);
            if (i == 35 && arrayData[i].Number.Value == 1 && arrayData[i].Number.Unit == 0)
            {
                victory.showText();
            }
        }
        else
        {
            StartCoroutine("showError");
        }
    }

    IEnumerator showError()
    {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(4);
        errorMessage.SetActive(false);
    }
}
