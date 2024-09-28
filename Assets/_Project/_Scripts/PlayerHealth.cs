using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Image Bar;


   public void SetAmount(float amount)
    {
        Bar.fillAmount = amount;
    }
}
