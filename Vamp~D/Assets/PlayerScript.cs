using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerInputSystem PlayerInputSystem;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed;
    private void Awake()
    {
        PlayerInputSystem = new PlayerInputSystem();
    }
    private void OnEnable()
    {
        EnableInput();
    }
    private void OnDisable()
    {
        DisableInput(); 
    }
    private void Start()
    {   
        
    }




    private void FixedUpdate()
    {
        Vector2 moveVector = PlayerInputSystem.Player.Move.ReadValue<Vector2>();
        // _rigidBody.velocity = (transform.forward * moveVector.x) * _speed * Time.deltaTime;
        Debug.Log(_speed * moveVector * Time.deltaTime);
        _rigidBody.velocity = moveVector * _speed * Time.deltaTime;
    }


    //Movement
    private void Move(InputAction.CallbackContext context)
    {
       
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log("PEW PEW");
    }

    private void EnableInput()
    {
        PlayerInputSystem.Player.Move.Enable();
        PlayerInputSystem.Player.Move.performed += Move;
        PlayerInputSystem.Player.Shoot.Enable();
        PlayerInputSystem.Player.Shoot.performed += Shoot;
    }
    private void DisableInput()
    {
        PlayerInputSystem.Player.Move.Disable();
        PlayerInputSystem.Player.Move.performed -= Move;
        PlayerInputSystem.Player.Shoot.Disable();
        PlayerInputSystem.Player.Shoot.performed -= Shoot;
    }
}
