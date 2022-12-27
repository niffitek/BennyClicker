using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEmoteController : MonoBehaviour
{
    private float speed = 75;
    Vector2 target;
    RectTransform rectTransform;
    public bool isClone = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(Random.Range(-900, 900), 600);
        target = new Vector2(Random.Range(-900, 900), -600);
    }

    void Update()
    {
        if (isClone)
        {
            if (rectTransform.anchoredPosition == target)
            {
                Destroy(this.gameObject);
            }
            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, target, speed * Time.deltaTime);
        }
    }
}
