using UnityEngine;
using System;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]
[RequireComponent (typeof(SpriteRenderer))]
public class FrutasController : MonoBehaviour
{
    private Rigidbody2D RB2D;
    private SpriteRenderer spriteRenderer;  
    private float speed;
    private float point;
    public static event Action<float> eventPoint;

    public enum FruitType
    {
        Apple,
        Banana,
        Cherry,
        Chocolate,
        Velocity,
        Time
    }

    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite bananaSprite;
    [SerializeField] private Sprite cherrySprite;
    [SerializeField] private Sprite chocolate;
    [SerializeField] private Sprite velocity;
    [SerializeField] private Sprite time;

    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void FixedUpdate()
    {
        RB2D.velocity = new Vector2(0, -speed);
    }

    private void ActiveEventPoint(float point)
    {
        eventPoint?.Invoke(point);
    }
    public void SetFruitSprite(FruitType type)
    {
        switch (type)
        {
            case FruitType.Apple:
                spriteRenderer.sprite = appleSprite;
                speed = 4;
                point = 8;
                break;
            case FruitType.Banana:
                spriteRenderer.sprite = bananaSprite;
                speed = 2;
                point = 3;
                break;
            case FruitType.Cherry:
                spriteRenderer.sprite = cherrySprite;
                speed = 3;
                point = 5;
                break;
            case FruitType.Chocolate:
                spriteRenderer.sprite = chocolate;
                speed = 3;
                point = -5;
                transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                this.gameObject.tag = "Malos";
                break;
            case FruitType.Velocity:
                spriteRenderer.sprite = velocity;
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                speed = 3;
                point = 0;
                gameObject.tag = "Velocity";
                break;
            case FruitType.Time:
                spriteRenderer.sprite = time;
                transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                gameObject.tag = "Time";
                speed = 3;
                point = 0;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            if (this.gameObject.tag != "Malos")
            {
                ActiveEventPoint(-5);
            }
            else
            {
                ActiveEventPoint(0);
            }
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            ActiveEventPoint(point);
            Destroy(this.gameObject);
        }
       
    }
}
