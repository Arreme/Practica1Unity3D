using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{

    private Pool _decalPool;
    [SerializeField] private float _distance = 5f;
    [SerializeField] private float zOffset;
    [SerializeField] private float _despawn = 1f;
    [SerializeField] private LayerMask _layer;

    public void setDecal(Pool _decal)
    {
        _decalPool = _decal;
    }

    public void Update()
    {
        RaycastHit info;
        if (Physics.Raycast(new Ray(transform.position, -transform.forward),out info,_distance,_layer))
        {
            Debug.Log("Hey");
            info.transform.GetComponent<Interaction>()?.runInteraction();
            GameObject decal = _decalPool.decalActivateObject(info.point + info.normal * zOffset, Quaternion.LookRotation(-info.normal));
            decal.transform.parent = info.transform;
            gameObject.SetActive(false);
        }
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
