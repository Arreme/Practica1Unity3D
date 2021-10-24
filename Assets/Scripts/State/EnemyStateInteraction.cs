using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyStateInteraction : Interaction
{
    [SerializeField] private float _life = 50;
    [SerializeField] private MonoBehaviour _chaseState;

    [SerializeField] private MonoBehaviour[] _allStates;
    [SerializeField] private Animation _anim;

    [SerializeField] private GameObject[] _items;

    private NavMeshAgent _navMesh;
    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    public override void runInteraction()
    {
        _navMesh.isStopped = true;
        _chaseState.enabled = true;
        foreach (MonoBehaviour mono in _allStates) mono.enabled = false;
        _life -= Shooter.CurrentGun._damage;
        if (_life <= 0)
        {
            GameObject go = Instantiate(_items[Random.Range(0,3)],transform.position,transform.rotation);
            gameObject.SetActive(false);
        } else
        {
            _anim.CrossFade("DamageEnemy");
            StartCoroutine(waitForChase());
        }
    }

    private IEnumerator waitForChase()
    {
        yield return new WaitForSeconds(1f);
        _navMesh.isStopped = false;
    }

    private void OnDisable()
    {
        Destroy(gameObject, 1);
    }
}
