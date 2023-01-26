using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //add of remove an InteractionEvent to this game object.
    public bool useEvents;

    //message displayed to player when they look at interactable object
    [SerializeField]
    public string promptMessage;
    //this function will be called from our player
    public void BaseInteract()
    {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {
        //no code here. will be overwritten by our subclasses (template function)
    }
}
