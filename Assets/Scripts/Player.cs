using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float camMoveSpeed;
    [SerializeField] Vector2 bounds;
    float speedModifier = 1;

    [Header("New Input System")]
    InputSystem_Actions inputActions;
    InputAction move;

    [Header("Objects")]
    [SerializeField] Collider2D coll;
    [SerializeField] new SpriteRenderer renderer;

    Rigidbody2D rb;

    [SerializeField]
    private float multiplier = 2f, minZoom = 1f, maxZoom = 10f, smoothTime = .1f;
    private float velocity = 0f;

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

        DayNightCycle.Cycle += TogglePlayer;
    }
    void OnDisable()
    {
        move.Disable();

        DayNightCycle.Cycle -= TogglePlayer;
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

        Vector2 clampedPosition = new(
            Mathf.Clamp(rb.position.x, -bounds.x, bounds.x), Mathf.Clamp(rb.position.y, -bounds.y, bounds.y));
        rb.position = clampedPosition;
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

    void TogglePlayer(bool value)
    {
        renderer.enabled = value;
        coll.enabled = value;
        if (value) 
            transform.position = Vector3.one;
    }
}
