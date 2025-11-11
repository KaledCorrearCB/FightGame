using UnityEngine;
using UnityEngine.InputSystem; // Necesario para el nuevo Input System
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(CharacterController))]
public class FightingController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 5f;   // Velocidad de desplazamiento
    [SerializeField] private float rotationSpeed = 10f; // Velocidad de rotación hacia el oponente


    public float smoothBlend = 0.1f;
    private CharacterController controller;
    private Vector2 moveInput;
    private Transform cameraTransform;
    private Animator anim;
    private PlayerInput playerInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        // Si usas PlayerInput, asegúrate de tener las acciones conectadas correctamente
    }

    public void Start()
    {
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

    }

    private void Update()
    {
        GetInput();
        MoveCharacter();

        Debug.Log(moveInput.x);
        Debug.Log(moveInput.y);
        

    }

    // Método llamado automáticamente por el Input System
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void GetInput()
    {
        moveInput = playerInput.actions["Movimiento"].ReadValue<Vector2>();
    }

    private void MoveCharacter()
    {
        // Convertimos el input 2D (x,y) a dirección 3D (x,z)
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);

        // Mantener movimiento relativo a la cámara (opcional)
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        Vector3 move = (right * direction.x + forward * direction.z).normalized;

        // Mover al personaje
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Rotar hacia la dirección de movimiento (solo si hay movimiento)
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            

        }

        anim.SetFloat("Blend", moveInput.magnitude, smoothBlend, Time.deltaTime);

    }

  


}