using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateInteraction : Interaction
{
    [SerializeField] private float _life = 50;
    [SerializeField] private MonoBehaviour _chaseState;

    [SerializeField] private MonoBehaviour[] _allStates;
    public override void runInteraction()
    {
        _chaseState.enabled = false;
        foreach (MonoBehaviour mono in _allStates) mono.enabled = false;
        _life -= Shooter.CurrentGun._damage;
        //check if dead
        //run animation
        _chaseState.enabled = true;
    }
}
