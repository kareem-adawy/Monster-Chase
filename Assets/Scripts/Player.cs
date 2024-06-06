using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce =11f;

    private float movementX;
    private float movementY;

    public Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
       


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();

    }

    private void FixedUpdate()
    {
        PlayerJump();

    }


    void PlayerMoveKeyboard() {

        movementX = Input.GetAxisRaw("Horizontal");
        
        //movementY = Input.GetAxisRaw("Vertical");
        //transform.position += new Vector3(0f, movementY, 0f) * jumpForce * Time.deltaTime;

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;

        } else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } else
        {
            anim.SetBool(WALK_ANIMATION, false);

        }



    }

    void PlayerJump()
    {
        if ((Input.GetKey("w") || Input.GetButtonDown("Jump")) && isGrounded)
        {
            //Debug.Log("Jump");
            anim.SetBool(JUMP_ANIMATION, true);
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            anim.SetBool(JUMP_ANIMATION, false);


        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            MonsterSpawner.isdead = true;
            Destroy(gameObject);

        }
    }


    

}
