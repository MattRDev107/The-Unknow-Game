using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingEject : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float forceMin;
    public float forceMax;
    public AudioClip dropSound;
    public LayerMask layerMask;
    public float Lifetime;
    public float fadetime;
    public float randomXMin, randomXMax;
    public float randomYMin, randomYMax;
    public float forcePushMin, forcePushMax;
    public float volumeMax, volumeMin;
    private float volume;


    void Start () {
        float force = Random.Range(forceMin, forceMax);
        volume = Random.Range(volumeMax, volumeMin);
        float dirX = Random.Range(randomXMin, randomXMax);
        float dirY = -Random.Range(randomYMin, randomYMax);
        float pushForce = Random.Range(forcePushMin, forcePushMax);
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(dirX, dirY) * pushForce);
        rb2d.AddTorque(Random.insideUnitSphere.z * force);
        StartCoroutine(Fade());
    }

    void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(dropSound, transform.position, volume);
    }

    IEnumerator Fade() {
        yield return new WaitForSeconds(Lifetime);

        float percent = 0;
        float fadeSpeed = 1 / fadetime;
        SpriteRenderer spriteRen = GetComponent<SpriteRenderer>();
        Color initialColor = spriteRen.color;

        while (percent < 1){
            percent += Time.deltaTime * fadeSpeed;
            spriteRen.color = Color.Lerp(initialColor,Color.clear, percent);
            yield return null;
        }

        Destroy(gameObject);
    }
}
