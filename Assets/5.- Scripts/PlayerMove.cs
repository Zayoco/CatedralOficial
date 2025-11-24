using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    public float SpeedMove = 5f;
    public float gravity = -9.81f;
    private CharacterController controller;
    private Vector3 velocity;    
    private bool isGrounded;      

    private bool estaCaminando = false;
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (joystick == null)
        {
            joystick = FindObjectOfType<FixedJoystick>();
        }
    }

    void Update()
    {
        if (joystick == null || controller == null)
            return;

        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(move * SpeedMove * Time.deltaTime);

        bool movimientoActual = move.magnitude > 0.1f;

        if (movimientoActual && !estaCaminando)
        {
            estaCaminando = true;
            Debug.Log("El jugador comenz� a moverse");
            SoundEvents.Pasos?.Invoke(); 

        }
        else if (!movimientoActual && estaCaminando)
        {

            SoundEvents.DetenerPasos?.Invoke(); 
            estaCaminando = false;
            Debug.Log("El jugador se detuvo");
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

