using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactee : MonoBehaviour
{
    public void ShowInteractionPrompt(GameObject whoInteracted)
    {
        Debug.Log(whoInteracted.name + " interacted with " + gameObject.name);
    }
}