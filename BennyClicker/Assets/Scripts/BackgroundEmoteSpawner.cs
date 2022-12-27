using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundEmoteSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;
    public UpgradeHandler upgradeHandler;

    IEnumerator Start()
    {
        int i = 0;
        ScoreHandler scoreHandler = GetComponent<ScoreHandler>();

        while (true)
        {
            if (scoreHandler.score.Unit > 0)
            {
                i = scoreHandler.score.Unit * 3;
                for (; i > 0; i -= 1)
                {
                    SpawnEmote();
                    yield return new WaitForSeconds(1f);
                }
            }
            yield return new WaitForSeconds(5f);
        }
    }

    void SpawnEmote()
    {
        int i = Random.Range(0, upgradeHandler.arrayData.Length);

        while (upgradeHandler.arrayData[i].Number.Value == 0 && upgradeHandler.arrayData[i].Number.Unit == 0)
        {
            i = Random.Range(0, upgradeHandler.arrayData.Length);
        }

        var loadedSprite = Resources.Load<Sprite>(upgradeHandler.arrayData[i].SpritePath);
        GameObject newObject = Instantiate(prefab);
        newObject.GetComponent<BackgroundEmoteController>().isClone = true;
        newObject.GetComponent<Image>().sprite = loadedSprite;
        newObject.transform.parent = parent.transform;
    }
}
