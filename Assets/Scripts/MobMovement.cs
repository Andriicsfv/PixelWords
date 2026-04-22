using UnityEngine;

public class MobMovement : MonoBehaviour
{
    [Header("Налаштування руху")]
    public float speed = 2f;          
    public float walkDistance = 3f;   

    private Vector2 startPos;         
    private bool movingRight = true;  
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
       
        float leftEdge = startPos.x - walkDistance;
        float rightEdge = startPos.x + walkDistance;

        
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightEdge)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftEdge)
            {
                movingRight = true;
                Flip();
            }
        }

        
        if (anim != null)
        {
            float moveXValue = movingRight ? 1f : -1f;
            anim.SetFloat("MoveX", Mathf.Abs(moveXValue));
        }
    }

    void Flip()
    {
        
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !movingRight;
        }
        
    }
}