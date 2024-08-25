using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float camMoveSpeed;
    float speedModifier = 1;

    [Header("New Input System")]
    InputSystem_Actions inputActions;
    private InputAction move;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        move = inputActions.Player.Move;
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
    void Update()
    {
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, Time.deltaTime);
        Vector3 camPos = Vector2.Lerp(Camera.main.transform.position, rb.position, camMoveSpeed * Time.deltaTime);
        camPos.z = -10;
        Camera.main.transform.position = camPos;
    }

    void MovePlayer() => rb.linearVelocity = moveSpeed * speedModifier * move.ReadValue<Vector2>().normalized;

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tree":
                speedModifier = 0.5f;
                break;
            default:
                break;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tree":
                speedModifier = 1f;
                break;
            default:
                break;
        }
    }
}
