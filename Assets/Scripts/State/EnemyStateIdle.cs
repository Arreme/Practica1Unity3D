using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateIdle : MonoBehaviour
{
    [SerializeField] private float _waitForChange;
    [SerializeField] private MonoBehaviour _nextState;
    private void Start()
    {
        StartCoroutine(ChangeState());
    }

    private IEnumerator ChangeState()
    {
        yield return new WaitForSecondsRealtime(_waitForChange);
        _nextState.enabled = true;
        enabled = false;
    }
}
