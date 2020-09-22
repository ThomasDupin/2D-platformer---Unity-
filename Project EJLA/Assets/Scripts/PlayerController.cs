using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    private bool isGrounded;
    private SpriteRenderer theSR;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

   public ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmission;

    public ParticleSystem impactEffect;
   // private bool wasOnGround;
    public Transform camTarget;
    public float aheadAmount, aheadSpeed;
    private bool canDoubleJump;
    private Animator anim;
    public float KnockBackLenght, KnockBackForce;   
    private float KnockBackCounter;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
        footEmission = footsteps.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if(KnockBackCounter <=0)
        {
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if(isGrounded)
        {
            canDoubleJump = true;
        }
         if(Input.GetButtonDown("Jump"))
         {
             if(isGrounded)
             {
             theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
             }
         
         else
         {
            if(canDoubleJump)
            {
               theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
               canDoubleJump = false;
            }
         }
    }
        if(Input.GetButtonUp("Jump") && theRB.velocity.y > 0)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y * .5f);
        }
        if(theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        } else if(theRB.velocity.x > 0)
        {
            theSR.flipX = false;
        }

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            camTarget.localPosition = new Vector3(Mathf.Lerp(camTarget.localPosition.x, aheadAmount * Input.GetAxisRaw("Horizontal"), aheadSpeed * Time.deltaTime), camTarget.localPosition.y, camTarget.localPosition.z);
        }

        if(Input.GetAxisRaw("Horizontal") !=0 && isGrounded)
        {
            footEmission.rateOverTime = 35f;
        }else
        {
            footEmission.rateOverTime = 0f;
        }
     /*   if(!wasOnGround && isGrounded)
        {
            impactEffect.gameObject.SetActive(true);
            impactEffect.Stop();
            impactEffect.transform.position = footsteps.transform.position;
            impactEffect.Play();
        }
        wasOnGround = isGrounded;
*/
        }else
        {
            KnockBackCounter -= Time.deltaTime;
            if(!theSR.flipX)
            {
                theRB.velocity = new Vector2(-KnockBackForce,theRB.velocity.y);
            }else
            {
               theRB.velocity = new Vector2(KnockBackForce,theRB.velocity.y);

            }
        }
        anim.SetFloat("MoveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded); 
    }

    public void KnocBack()
    {
        KnockBackCounter = KnockBackLenght;
        theRB.velocity = new Vector2(0f,KnockBackForce);
    }
    }
