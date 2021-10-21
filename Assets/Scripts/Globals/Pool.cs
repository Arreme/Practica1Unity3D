using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject decalPool;
    private List<GameObject> decalPooledObjects;

    [SerializeField] private GameObject bulletsPool;
    private List<GameObject> bulletPooledObjects;

    [SerializeField] private int poolSize = 20;

    private void Start()
    {
        decalPooledObjects = new List<GameObject>();
        bulletPooledObjects = new List<GameObject>();
        for(int i = 0; i<poolSize; i++)
        {
            GameObject go = Instantiate(decalPool);
            decalPooledObjects.Add(go);
            go.SetActive(false);

            go = Instantiate(bulletsPool);
            bulletPooledObjects.Add(go);
            go.GetComponent<TargetHit>()?.setDecal(this);
            go.SetActive(false);
        }
    }

    public GameObject decalActivateObject(Vector3 pos, Quaternion orientation)
    {
        GameObject pulled = getDecalObject();
        if (pulled != null)
        {
            pulled.transform.position = pos;
            pulled.transform.rotation = orientation;
            pulled.SetActive(true);
        }
        return null;
    }

    public GameObject getDecalObject()
    {
        return decalPooledObjects.Find(x => !x.activeInHierarchy);
    }

    public GameObject bulletActivateObject(Vector3 pos, Quaternion orientation)
    {
        GameObject pulled = getBulletObj();
        if (pulled != null)
        {
            pulled.transform.position = pos;
            pulled.transform.rotation = orientation;
            pulled.SetActive(true);
            pulled.GetComponent<TargetHit>().activateCounter();
            return pulled;
        }
        return null;
    }

    public GameObject getBulletObj()
    {
        return bulletPooledObjects.Find(x => !x.activeInHierarchy);
    }
}
