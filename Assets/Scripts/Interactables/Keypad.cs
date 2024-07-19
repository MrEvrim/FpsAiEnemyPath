using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        //yok etme falan burdan
        doorOpen=!doorOpen;
        //IsOpen Animasyondan Geliyor.
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
       
    }
}
