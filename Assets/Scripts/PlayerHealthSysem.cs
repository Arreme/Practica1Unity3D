using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthSysem : MonoBehaviour
{
    [SerializeField] float _health;
    private const float _MAXHEALTH = 100;
    [SerializeField] float _shield;
    private const float _MAXSHIELD = 100;

    [SerializeField] private UnityEvent<float> _healthEvent;
    [SerializeField] private UnityEvent<float> _shieldEvent;

    //Problem with trigger detection, we need to put this here :(
    [SerializeField] private Shooter _shooter;

    public void getHit()
    {
        if (_shield > 0)
        {
            _shield -= 75;
            _shield = _shield < 0 ? 0 : _shield;
            _shieldEvent.Invoke(_shield);
        } else
        {
            _health -= 25;
            _health = _health < 0 ? 0 : _health;
            _healthEvent.Invoke(_health);
            if (_health <= 0)
            {
                S_GameManager._gameManager.DeathEvent();
            }
        }
    }

    public bool giveHealth(float value)
    {
        if (_health == _MAXHEALTH) return false;
        _health += value;
        _health = _health > _MAXHEALTH ? _MAXHEALTH : _health;
        _healthEvent.Invoke(_health);
        return true;
    }

    public bool giveShield(float value)
    {
        if (_shield == _MAXSHIELD) return false;
        _shield += value;
        _shield = _shield > _MAXSHIELD ? _MAXSHIELD : _shield;
        _shieldEvent.Invoke(_shield);
        return true;
    }

    public bool bridgeShooter(int value)
    {
        return _shooter.giveAmmo(value);
    }
}
