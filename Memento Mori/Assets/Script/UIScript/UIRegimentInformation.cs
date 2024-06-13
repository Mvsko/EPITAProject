using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRegimentInformation : MonoBehaviour
{
    public Regiment regiment;

    public TextMeshProUGUI Damage;
    public TextMeshProUGUI Speed;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Armor;
    public TextMeshProUGUI Moral;

    public Image healthBarImage;
    public Image ArmorBarImage;
    public Image MoralBarImage;

public void RegimentInfoActivate(List<GameObject> regs)
{
    if(regs.Count==1)
    {
        regiment = regs[0].GetComponent<Regiment>();
        gameObject.SetActive(true);
    }
    else
    {
        regiment = null;
        gameObject.SetActive(false);
    }
    
}
void Update()
    {
        if(regiment != null)
        {
            
            healthBarImage.fillAmount = regiment.regimentHealth/regiment.regimentMaxHealth;
            ArmorBarImage.fillAmount = regiment.armure/regiment.unit.armure;
            MoralBarImage.fillAmount = regiment.moral/regiment.unit.moral;
            Damage.text = $"Degat: {regiment.unit.degatMelee}";
            Speed.text = $"Vitesse: {regiment.unit.vitesse}";
            Health.text = $"Santé: {(int)regiment.regimentHealth}";
            Armor.text = $"Armure: {(int)regiment.armure}";
            Moral.text =$"Moral: {(int)regiment.moral}";
        }
    }
        
}
