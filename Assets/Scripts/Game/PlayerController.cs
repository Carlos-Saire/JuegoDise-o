using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float speed;
    private Rigidbody2D RB2D;

    [Header("Limites")]
    [SerializeField] private float Xmin;
    [SerializeField] private float XMax;
    private float currentX;

    private float xdirection;
    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        currentX = Mathf.Clamp(transform.position.x, Xmin, XMax);
        transform.position = new Vector2(currentX, transform.position.y);
    }
    public void XDirection(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
        xdirection = context.ReadValue<float>();
    }
    private void FixedUpdate()
    {
        RB2D.velocity = new Vector2(xdirection*speed, RB2D.velocity.y);
    }
}
