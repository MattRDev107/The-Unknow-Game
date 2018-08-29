using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsCheck2D : MonoBehaviour {

    public LayerMask RaycastHitMask;
    public float raycastLength = 0;

    const float skinWidth = .015f;

    private Rigidbody2D rb;
    private BoxCollider2D PlayerCollider;
    private RaycastOrgins raycastOrgins;
    private RaycastHits raycastHits;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<BoxCollider2D>();
        Physics2D.queriesStartInColliders = false;
    }

    void Update() {
        UpdateRayCastOrigins();
        DisplayRaycast();
        CheckForCollision();
    }

    public CollisionFlags CollisionFlags() {
        if(raycastHits.Above_1 || raycastHits.Above_2) {
            return UnityEngine.CollisionFlags.Above;
        }
        else if(raycastHits.Below_1 || raycastHits.Below_2) {
            return UnityEngine.CollisionFlags.Below;
        }
        else if ((raycastHits.Right_1 || raycastHits.Right_2)||(raycastHits.Left_1 || raycastHits.Left_2)) {
            return UnityEngine.CollisionFlags.Sides;
        }

        return UnityEngine.CollisionFlags.None;
    }

    void DisplayRaycast() {
        Debug.DrawRay(raycastOrgins.topRight, Vector2.up * raycastLength, Color.red);
        Debug.DrawRay(raycastOrgins.topLeft, Vector2.up * raycastLength, Color.yellow);
        Debug.DrawRay(raycastOrgins.bottomRight, Vector2.down * raycastLength, Color.green);
        Debug.DrawRay(raycastOrgins.bottomLeft, Vector2.down * raycastLength, Color.blue);
        Debug.DrawRay(raycastOrgins.topRight, Vector2.right * raycastLength, Color.red);
        Debug.DrawRay(raycastOrgins.bottomRight, Vector2.right * raycastLength, Color.yellow);
        Debug.DrawRay(raycastOrgins.topLeft, Vector2.left * raycastLength, Color.green);
        Debug.DrawRay(raycastOrgins.bottomLeft, Vector2.left * raycastLength, Color.blue);
    }

    public void CheckForCollision() {
        raycastHits.Above_1 = Physics2D.Raycast(raycastOrgins.topRight, Vector2.up, raycastLength, RaycastHitMask);
        raycastHits.Above_2 = Physics2D.Raycast(raycastOrgins.topLeft, Vector2.up, raycastLength, RaycastHitMask);
        raycastHits.Below_1 = Physics2D.Raycast(raycastOrgins.bottomRight, Vector2.down, raycastLength, RaycastHitMask);
        raycastHits.Below_2 = Physics2D.Raycast(raycastOrgins.bottomLeft, Vector2.down, raycastLength, RaycastHitMask);
        raycastHits.Right_1 = Physics2D.Raycast(raycastOrgins.topRight, Vector2.right, raycastLength, RaycastHitMask);
        raycastHits.Right_2 = Physics2D.Raycast(raycastOrgins.bottomRight, Vector2.right, raycastLength, RaycastHitMask);
        raycastHits.Left_1 = Physics2D.Raycast(raycastOrgins.topLeft, Vector2.left, raycastLength, RaycastHitMask);
        raycastHits.Left_2 = Physics2D.Raycast(raycastOrgins.bottomLeft, Vector2.left, raycastLength, RaycastHitMask);
    }

    void UpdateRayCastOrigins() {
        Bounds bounds = PlayerCollider.bounds;
        bounds.Expand(-skinWidth);

        raycastOrgins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrgins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrgins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrgins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    struct RaycastOrgins {
        public Vector2 topRight, topLeft;
        public Vector2 bottomRight, bottomLeft;
    }
    public struct RaycastHits {
        public RaycastHit2D Above_1, Above_2;
        public RaycastHit2D Below_1, Below_2;
        public RaycastHit2D Right_1, Right_2;
        public RaycastHit2D Left_1, Left_2;
    }

}
