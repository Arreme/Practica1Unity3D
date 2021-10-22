using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField] private float seconds = 2;

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {

        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Invoke("UnAttach", 0.1f);
    }

    private void UnAttach()
    {
        transform.parent = null;
        gameObject.SetActive(false);
    }
}
