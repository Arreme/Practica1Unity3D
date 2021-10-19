using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text2;

    [SerializeField] private Image _health;
    [SerializeField] private Image _shield;

    public void updateAmmo(int loadedBullets, int unloadedBullets)
    {
        text.text = loadedBullets.ToString() + "/" + unloadedBullets.ToString();
        text2.text = text.text;
    }

    public void updateHealth(float health)
    {
        _health.fillAmount = health / 100;
    }

    public void updateShield(float shield)
    {
        _shield.fillAmount = shield / 100;
    }
}
