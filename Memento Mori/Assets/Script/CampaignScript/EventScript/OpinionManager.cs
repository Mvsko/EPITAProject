using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
public class OpinionManager : MonoBehaviour
{

    public float MilitaryOpinion = 50f;
    public float MaxMilitaryOpinion = 100f;

    public Image MilitaryBarImage;

    // Update is called once per frame
    void Update()
    {
        MilitaryBarImage.fillAmount = MilitaryOpinion/MaxMilitaryOpinion;
    }
}
