using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{

    private Pool _decalPool;
    [SerializeField] private float zOffset;
    [SerializeField] private float _despawn = 1f;

    public void setDecal(Pool _decal)
    {
        _decalPool = _decal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint hit = collision.contacts[0];
        _decalPool.decalActivateObject(hit.point + hit.normal * zOffset, Quaternion.LookRotation(-hit.normal));
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Interaction>()?.runInteraction();
    }

    public void activateCounter()
    {
        StartCoroutine(despawn());
    }

    private IEnumerator despawn()
    {
        yield return new WaitForSecondsRealtime(_despawn);
        if (gameObject.activeInHierarchy) gameObject.SetActive(false);
    }
}
