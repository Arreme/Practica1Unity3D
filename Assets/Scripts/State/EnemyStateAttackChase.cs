using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateAttackChase : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private Transform _target;
    private Animation _anim;
    private bool _inRange = false;
    private bool _canAttack = true;
    private void Awake()
    {
        _anim = GetComponent<Animation>();
    }

    private void Update()
    {
        _navMesh.destination = _target.position;
        if (_inRange && _canAttack)
        {
            StartCoroutine(attackCooldown());
            _anim.CrossFade("AttackEnemy");
        }
    }

    public void TriggerEnterExitEvent(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = !_inRange;
            _navMesh.isStopped = _inRange;
        }
    }

    public void TriggerEnterAttackEvent(Collider other)
    {
        other.GetComponent<PlayerHealthSysem>()?.getHit();
    }

    private IEnumerator attackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(1f);
        _canAttack = true;
    }
}
