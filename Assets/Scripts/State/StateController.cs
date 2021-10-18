using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (NavMeshAgent))]
public class StateController : MonoBehaviour
{

    I_State _currState;
    public S_Idle _idleState = new S_Idle();
    public S_Patrol _patrolState = new S_Patrol();
    [SerializeField] public Transform[] _targetData; 
    public NavMeshAgent _navMesh; 


    // Start is called before the first frame update
    void Start()
    {
        _currState = _idleState;
        _navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _currState.updateState();
    }


    public void changeState (I_State newState)
    {
        _currState = newState;
        _currState.startState(this);
    }


}
