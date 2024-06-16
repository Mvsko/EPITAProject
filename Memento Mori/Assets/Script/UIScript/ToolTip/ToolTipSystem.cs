using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    private static ToolTipSystem curent;

    public ToolTipScript toolTip;
    public void Awake()
    {
        curent = this;
    }
    public static void Show(string content, string header = "")
    {
        curent.toolTip.SetText(content,header);
        curent.toolTip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        curent.toolTip.gameObject.SetActive(false);
    }
}
