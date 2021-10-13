using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text2;

    public void updateAmmo(int loadedBullets, int unloadedBullets)
    {
        text.text = loadedBullets.ToString() + "/" + unloadedBullets.ToString();
        text2.text = text.text;

    }
}
