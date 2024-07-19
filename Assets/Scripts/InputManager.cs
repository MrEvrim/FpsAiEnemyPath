using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{

    //Input ve yazdıgın diğer methodları aktive et.
    private PlayerInput playerInput;

    public PlayerInput.YurumeActions yurume;

    private PlayerMotor motor;

    private PlayerLook look;





    //Awake ile inputları program ayağa kalkarken birbirine eşle lazım olan Inputtan gelen tuşa göre hangi Methodu kullanacağın.
    private void Awake()
    {
        playerInput = new PlayerInput();

        yurume = playerInput.Yurume;

        motor = GetComponent<PlayerMotor>();
        yurume.Zıpla.performed += ctx => motor.Jump();

        yurume.Egilme.performed += ctx => motor.Crouch();
        yurume.Kosma.performed += ctx => motor.Sprint();

        look = GetComponent<PlayerLook>();
    }


    private void FixedUpdate()
    {
        motor.ProcessMove(yurume.Hareket.ReadValue<Vector2>());
    }


    private void LateUpdate()
    {
        look.ProcessLook(yurume.Bak.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        yurume.Enable();
    }
    private void OnDisable()
    {
        yurume.Disable();
    }
}
