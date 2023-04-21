using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Card : DraggableObject
{
    public Vector3 initPosition;
    
    public override void OnStartDrag()
    {
        initPosition = transform.position;
    }

    public override void OnEndDrag()
    {
        print("Entro");
        transform.DOMove(initPosition, 0.5f);
    }

    protected override bool DragSuccessful()
    {
        return true;
    }
}
