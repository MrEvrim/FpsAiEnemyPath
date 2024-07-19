using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    //unity yap?ca??n hareketler ve hedeflerin.
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5.0f;
    private bool isGrounded;

    private float gravity = -9.8f;
    public float jumpHeight = 0.8f;

    private bool lerpCrouch;
    private bool crouching;
    private float crouchTimer;

    private bool sprinting;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        //e?er yerle ilgili temas varsa tetikler
        isGrounded = controller.isGrounded;
        //e?ilme ile ilgili
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);


            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void ProcessMove(Vector2 input)
    {
        //Inputan gelen WASD  verileri buraya gönder ve i?le.   VECTOR 2 OLARAK GEL?YOR
        Vector3 yurumeYonu = Vector3.zero;
        yurumeYonu.x = input.x;
        yurumeYonu.z = input.y;
        controller.Move(transform.TransformDirection(yurumeYonu) * speed * Time.deltaTime);
        //Yer çekimi ekleme
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


    }
    public void Jump()
    {
        //ayn? ?ekilde z?plama buttonu
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
            speed = 8;
        else
            speed = 5;

    }
}
