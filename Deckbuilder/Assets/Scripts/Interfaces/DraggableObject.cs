using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DraggableObject : MonoBehaviour
{
    public abstract void OnStartDrag();
    public abstract void OnEndDrag();

    public virtual bool CanDrag
    {
        get
        {
            return true;
        }
    }

    protected abstract bool DragSuccessful();
}
