using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
public class OpinionManager : MonoBehaviour
{
    private float MaxOpinion = 100f;

    public float MilitaryOpinion = 50f;
    public float SenatOpinion = 50f;
    public float RegionOpinion = 50f;

    
    public Image MilitaryBarImage;
    public Image SenatBarImage;
    public Image RegionBarImage;

    // Update is called once per frame
    void Update()
    {
        MilitaryBarImage.fillAmount = MilitaryOpinion/MaxOpinion;
        SenatBarImage.fillAmount = SenatOpinion/MaxOpinion;
        RegionBarImage.fillAmount = RegionOpinion/MaxOpinion;
    }
}
