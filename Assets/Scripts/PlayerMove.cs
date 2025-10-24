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
    private bool isGrounded;       // verifica si está tocando el suelo

    private bool estaCaminando = false;
    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Buscar automáticamente el joystick si no está asignado
        if (joystick == null)
        {
            joystick = FindObjectOfType<FixedJoystick>();
        }
    }

    void Update()
    {
        // Evitar errores si joystick o controller no existen aún
        if (joystick == null || controller == null)
            return;

        // Verificar si el jugador está tocando el suelo
        isGrounded = controller.isGrounded;

        // Si está tocando el suelo y tiene velocidad hacia abajo, resetearla
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Movimiento horizontal (por joystick)
        Vector3 move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(move * SpeedMove * Time.deltaTime);

        // Detectar si el jugador se está moviendo (con un pequeño umbral para evitar ruido)
        bool movimientoActual = move.magnitude > 0.1f;

        // Si cambia el estado de movimiento, imprimir solo una vez
        if (movimientoActual && !estaCaminando)
        {
            estaCaminando = true;
            Debug.Log("El jugador comenzó a moverse");
            SoundEvents.Pasos?.Invoke(); //Sonido by Chelo :D

        }
        else if (!movimientoActual && estaCaminando)
        {

            SoundEvents.DetenerPasos?.Invoke(); //Sonido by Chelo :D
            estaCaminando = false;
            Debug.Log("El jugador se detuvo");
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;

        // Aplicar el movimiento vertical (caída)
        controller.Move(velocity * Time.deltaTime);
    }
}

