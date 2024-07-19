using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;

    //oyuncu baktıgında etkileşim yapabildidiğine dair bir bilgi
    [SerializeField]
    public string promptMessage;
    public virtual string Onlook()
    {
        return promptMessage;
    }
    public void BaseInteract()
    {
        if (useEvents) 
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact(); 
    }
 

    protected virtual void Interact()
    {
        
    }
}
