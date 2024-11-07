using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ParticleSystem))]
public class PlayerController : MonoBehaviour
{
    private ParticleSystem particleSyste;

    [Header("Player")]
    [SerializeField] private float speed;
    private Rigidbody2D RB2D;
    private float xdirection;

    [Header("Limites")]
    [SerializeField] private float Xmin;
    [SerializeField] private float XMax;
    private float currentX;

    [Header("Sound")]
    [SerializeField] private AudioClipSO audioClipSO;
    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        particleSyste=GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        currentX = Mathf.Clamp(transform.position.x, Xmin, XMax);
        transform.position = new Vector2(currentX, transform.position.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            particleSyste.Play();
            audioClipSO.PlayOneShoot();
        }
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
