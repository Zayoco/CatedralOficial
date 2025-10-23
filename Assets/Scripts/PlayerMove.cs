using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    public float SpeedMove = 5f;
    public float gravity = -9.81f; // fuerza de gravedad
    private CharacterController controller;
    private Vector3 velocity;      // almacena la velocidad vertical
    private bool isGrounded;       // verifica si est� tocando el suelo

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Buscar autom�ticamente el joystick si no est� asignado
        if (joystick == null)
        {
            joystick = FindObjectOfType<FixedJoystick>();
        }
    }

    void Update()
    {
        // Evitar errores si joystick o controller no existen a�n
        if (joystick == null || controller == null)
            return;

        // Verificar si el jugador est� tocando el suelo
        isGrounded = controller.isGrounded;

        // Si est� tocando el suelo y tiene velocidad hacia abajo, resetearla
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Movimiento horizontal (por joystick)
        Vector3 move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(move * SpeedMove * Time.deltaTime);

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;

        // Aplicar el movimiento vertical (ca�da)
        controller.Move(velocity * Time.deltaTime);
    }
}

