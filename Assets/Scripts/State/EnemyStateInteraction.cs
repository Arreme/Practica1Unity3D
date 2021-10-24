using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateInteraction : Interaction
{
    [SerializeField] private float _life = 50;
    [SerializeField] private MonoBehaviour _chaseState;

    [SerializeField] private MonoBehaviour[] _allStates;
    [SerializeField] private Animation _anim;
    public override void runInteraction()
    {
        Debug.Log("A me diste");
        _chaseState.enabled = false;
        foreach (MonoBehaviour mono in _allStates) mono.enabled = false;
        _life -= Shooter.CurrentGun._damage;
        if (_life <= 0)
        {
            gameObject.SetActive(false);
        } else
        {
            _anim.Play("DamageEnemy");
            StartCoroutine(waitForChase());
        }
    }

    private IEnumerator waitForChase()
    {
        yield return new WaitForSeconds(1f);
        _chaseState.enabled = true;
    }

}
