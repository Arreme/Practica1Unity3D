using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject objectToPool;
    private List<GameObject> pooledObjects;
    [SerializeField] private int poolSize = 20;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i<poolSize; i++)
        {
            GameObject go = Instantiate(objectToPool);
            pooledObjects.Add(go);
            go.SetActive(false);
        }
    }

    public GameObject activateObject(Vector3 pos, Quaternion orientation)
    {
        GameObject pulled = getPooledObject();
        if (pulled != null)
        {
            pulled.transform.position = pos;
            pulled.transform.rotation = orientation;
            pulled.SetActive(true);
        }
        return null;
    }

    public GameObject getPooledObject()
    {
        return pooledObjects.Find(x => !x.activeInHierarchy);
    }
}
