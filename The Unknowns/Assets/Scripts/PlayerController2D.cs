using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour {
    
    [Range(0,20)]
    public float speed;
    [Range(0,20)]
    public float inAirSpeed;
    public float Jumpheght;
    public float startTimeBtwShots;
    public GameObject projectile;
    public GameObject casing;
    public Transform caseEnjecter;
    public Transform start;
    public AudioSource ShotAudio;

    [HideInInspector]
    public bool facingRight = true;
    private float moveHorizontal;
    private float timeBtwShots;
    private Vector2 LeftStart;
    private Vector2 RightStart;
    private Vector2 target;
    private bool isGrounded = false;
    private bool isRunning = false;

    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    private CollisionsCheck2D collisionsCheck2D;
    private Animator anim;
    private CameraShake cameraShake;
    private ArmRotate armRotate;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        collisionsCheck2D = GetComponent<CollisionsCheck2D>();
        anim = GetComponent<Animator>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        armRotate = GameObject.FindGameObjectWithTag("Arms").GetComponent<ArmRotate>();
        Physics2D.queriesStartInColliders = false;
        timeBtwShots = startTimeBtwShots;
    }

    void Update() {
        FireShot(start, caseEnjecter,  Input.GetMouseButton(0));
        isGrounded = collisionsCheck2D.CollisionFlags() == CollisionFlags.Below;
        Animations();

        if (!facingRight && moveHorizontal > 0) {
            Flip();
        }
        else if (facingRight && moveHorizontal < 0) {
            Flip();
        }
    }

    void FixedUpdate() {
        moveHorizontal = Input.GetAxis("Horizontal");
        Move(moveHorizontal);
    }
   void Animations() {
        anim.SetBool("ground", isGrounded);
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        anim.SetFloat("vSpeed", rb.velocity.y);
    }

    void Move(float moveH) {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.velocity = Vector2.up * Jumpheght;
        }

        if (isGrounded) {
            rb.velocity = new Vector2(moveH * speed, rb.velocity.y);
        }
        else if (!isGrounded) {
            rb.velocity = new Vector2(moveH * inAirSpeed, rb.velocity.y);
        }
    }

    public void FireShot(Transform start, Transform enjector, bool canFireShot) {
        if(canFireShot && timeBtwShots <= 0) {
            ShotAudio.Play();
            Instantiate(projectile, start.position, armRotate.angle);
            Instantiate(casing, enjector.position, Quaternion.identity);
            cameraShake.shouldShake = true;
            timeBtwShots = startTimeBtwShots;
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
