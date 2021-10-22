using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public abstract void runInteraction();

    private void OnDisable()
    {
        Destroy(gameObject, 1);
    }
}
