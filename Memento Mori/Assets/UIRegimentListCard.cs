using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRegimentListCard : MonoBehaviour
{
    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}
