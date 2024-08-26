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
    InputAction zoom;

    [Header("Objects")]
    [SerializeField] Collider2D coll;
    [SerializeField] SpriteRenderer renderer;

    float seekZoom;

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
        //zoom = inputActions.Player.Zoom;
        //zoom.Enable();

        DayNightCycle.Cycle += TogglePlayer;
    }
    void OnDisable()
    {
        move.Disable();
        //zoom.Disable();

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
        /*
            if (zoom.ReadValue<float>() < 1)
                seekZoom += 1;
            else if (zoom.ReadValue<float>() > 1)
                seekZoom -= 1;

            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, seekZoom, Time.deltaTime);
        */
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
