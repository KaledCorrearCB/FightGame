using UnityEngine;
using UnityEngine.InputSystem; // Necesario para el nuevo Input System
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(CharacterController))]
public class FightingController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;   // Velocidad de desplazamiento
    [SerializeField] private float rotationSpeed = 10f; // Velocidad de rotación hacia el oponente



    public float smoothBlend = 0.1f;
    public CharacterController controller;
    private Vector2 moveInput;
    private Transform cameraTransform;
    private Animator anim;
    private PlayerInput playerInput;
    private Input actionInput;
    // Hacemos que sea un singleton para poder llamarlo desde otro lugar
    public static FightingController instance;
    public bool golpeado;
    [Header("Gravedad")]
    public float gravity = -9.8f;
    private float verticalVelocity = 0f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


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
        golpeado = false;

    }

    private void Update()
    {
        GetInput();
        MoveCharacter();

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

        // Movimiento relativo a la cámara
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        Vector3 move = (right * direction.x + forward * direction.z).normalized;

        // --- APLICAR GRAVEDAD ---
        if (controller.isGrounded)
        {
            // Si está en el suelo, asegúrate de que la velocidad vertical sea 0
            verticalVelocity = -1f;   // Un pequeño empuje hacia abajo para mantenerlo pegado
        }
        else
        {
            // Caída 
            verticalVelocity += gravity * Time.deltaTime;
        }

        // Crear vector final de movimiento
        Vector3 finalMovement = (move * moveSpeed) + new Vector3(0, verticalVelocity, 0);

        // Mover al personaje
        controller.Move(finalMovement * Time.deltaTime);

        // Rotar hacia la dirección de movimiento
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        anim.SetFloat("Blend", moveInput.magnitude, smoothBlend, Time.deltaTime);

    }

    public void MeGolpearon()
    {

        golpeado = true;


    }


}