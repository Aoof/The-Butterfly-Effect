using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : CollidableObjects
{
    private bool interacted = false;

    protected override void OnCollided(GameObject collededObject)
    {
        if(Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
    }

    protected virtual void OnInteract()
    {
        if(interacted != true)
        {
            interacted = true;
        }
    }
}
