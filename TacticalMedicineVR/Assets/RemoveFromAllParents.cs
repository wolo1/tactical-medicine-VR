using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFromAllParents : MonoBehaviour
{

    public void DetachFromAllParents()
    {
        // Traverse up the hierarchy and detach from each parent
        Transform currentParent = transform.parent;
        while (currentParent != null)
        {
            transform.SetParent(null);
            currentParent = transform.parent;
        }

    }
}
