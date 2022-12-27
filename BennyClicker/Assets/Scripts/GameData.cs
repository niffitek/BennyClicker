using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitType;
using UpgradeClass;

[System.Serializable]
public class GameData
{
    public double scoreValue;
    public int scoreUnit;

    public double clickIncreaseValue;
    public int clickIncreaseUnit;

    public double upgradeIncreaseValue;
    public int upgradeIncreaseUnit;

    public string[] spritePaths;
    public string[] names;
    public bool[] isClickIncreases;

    public double[] priceValues;
    public int[] priceUnits;

    public double[] increaseValues;
    public int[] increaseUnits;

    public double[] numberValues;
    public int[] numberUnits;

    public GameData(ScoreHandler scoreHandler, UpgradeHandler upgradeHandler)
    {
        int len = upgradeHandler.arrayData.Length;
        Upgrade[] upgrades = upgradeHandler.arrayData;

        scoreValue = scoreHandler.score.Value;
        scoreUnit = scoreHandler.score.Unit;

        clickIncreaseValue = scoreHandler.clickIncrease.Value;
        clickIncreaseUnit = scoreHandler.clickIncrease.Unit;

        upgradeIncreaseValue = scoreHandler.upgradeIncrease.Value;
        upgradeIncreaseUnit = scoreHandler.upgradeIncrease.Unit;

        spritePaths = new string[len];
        names = new string[len];
        isClickIncreases = new bool[len];

        priceValues = new double[len];
        priceUnits = new int[len];

        increaseValues = new double[len];
        increaseUnits = new int[len];

        numberValues = new double[len];
        numberUnits = new int[len];

        for (int i = 0; i < len; i += 1)
        {
            spritePaths[i] = upgrades[i].SpritePath;
            names[i] = upgrades[i].Name;
            isClickIncreases[i] = upgrades[i].IsClickIncrease;

            priceValues[i] = upgrades[i].Price.Value;
            priceUnits[i] = upgrades[i].Price.Unit;

            increaseValues[i] = upgrades[i].Increase.Value;
            increaseUnits[i] = upgrades[i].Increase.Unit;

            numberValues[i] = upgrades[i].Number.Value;
            numberUnits[i] = upgrades[i].Number.Unit;
        }
    }
}
