using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Range(0,20)]
    public float speed;
    [Range(0,1)]
    public float spread;
    public float hitDamge;
    public float timeBfDestroy;
    public ParticleSystem BlowUp;

    private Rigidbody2D rb2D;
    private PlayerController2D playerController;
    private float randomY;
    private Vector2 rightDir;

    void Start() {
        rightDir  = transform.right;
        randomY = Random.Range(-spread, spread);
        rb2D = GetComponent<Rigidbody2D>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2D>();
        rightDir = (!playerController.facingRight) ? -rightDir : rightDir;
    }

    void Update() {
        if(timeBfDestroy <= 0) {
            Instantiate(BlowUp, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else {
            timeBfDestroy -= Time.deltaTime;
        }
    }

    void FixedUpdate() {
        Vector2 randomSpread = new Vector2(0, randomY);
        Vector2 dir;
        dir = rightDir + randomSpread;
        rb2D.velocity = dir.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Instantiate(BlowUp, transform.position, Quaternion.identity);
        Destroy(gameObject);
 
    }
}