using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInteraction : Interaction
{
    [SerializeField] private int _points;
    public override void runInteraction()
    {
        StData.CurrentPuntuation += _points;
        gameObject.SetActive(false);
    }

}
