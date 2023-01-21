using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message displayed to player when they look at interactable object
    public string promptMessage;
    //this function will be called from our player
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //no code here. will be overwritten by our subclasses (template function)
    }
}
