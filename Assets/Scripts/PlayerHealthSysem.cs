using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSysem : MonoBehaviour
{
    [SerializeField] float _health;
    [SerializeField] float shield;

    public void getHit()
    {
        if (shield > 0)
        {
            shield -= 75;
            //Update UI
        } else
        {
            _health -= 25;
            //Update UI
            if (_health <= 0)
            {
                //DeathScreen
            }
        }
        
    }
}
