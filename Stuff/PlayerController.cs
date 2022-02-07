using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
    public float playerSpeed;
    public Vector2 jumpHeight;
    private bool isOnGround;
    public float positionRadius;
    public LayerMask ground;
    
    public Transform PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
         Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
         for(int i = 0; i < colliders.Length; i++)
         {
             for(int k = i + 1; k < colliders.Length; k++ )
                 Physics2D.IgnoreCollision(colliders[i], colliders[k]);
         }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if(Input.GetAxisRaw("Horizontal") < 0)
            {
                anim.Play("Walk");
                rb.AddForce(Vector2.right * playerSpeed * Time.fixedDeltaTime);
            }else
            {
                anim.Play("WalkBack");
                rb.AddForce(Vector2.left * playerSpeed * Time.fixedDeltaTime);
            }
        }
        else{
            isOnGround = Physics2D.OverlapCircle(PlayerPos.position, positionRadius, ground);
            if(isOnGround == true && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Jumping");
                rb.AddForce(Vector2.up * jumpForce  * Time.fixedDeltaTime);
            }

        }
    }
}
