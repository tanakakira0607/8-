using UnityEngine;

public class sph : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Fluid Core")]
    public float radius = 0.6f;
    public float restDensity = 8f;
    public float pressureK = 8f;
    public float viscosity = 0.15f;
    public float surfaceTension = 3f;

    [Header("Movement")]
    public float initialSpeed = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.right * initialSpeed;
        rb.gravityScale = 1f;
        rb.linearDamping = 0.2f;
    }

    void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        float density = 0f;

        //密度計算
        foreach (Collider2D hit in hits)
        {
            Rigidbody2D other = hit.GetComponent<Rigidbody2D>();
            if (other == null) continue;

            float dist = Vector2.Distance(rb.position, other.position);

            if (dist < radius)
            {
                float q = 1f - dist / radius;
                density += q * q;
            }
        }

        
        float pressure = pressureK * (density - restDensity);

        
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject == gameObject) continue;

            Rigidbody2D other = hit.GetComponent<Rigidbody2D>();
            if (other == null) continue;

            Vector2 dir = rb.position - other.position;
            float dist = dir.magnitude;

            if (dist <= 0.001f || dist >= radius) continue;

            Vector2 normal = dir / dist;
            float q = 1f - dist / radius;
            //圧力
            float pressureForce = pressure * q;

            Vector2 force = normal * pressureForce;

            rb.AddForce(force * 0.5f);
            other.AddForce(-force * 0.5f);
            //粘性力
            Vector2 velDiff = rb.linearVelocity - other.linearVelocity;
            float u = Vector2.Dot(velDiff, normal);

            if (u > 0)
            {
                Vector2 impulse = q * viscosity * u * normal;

                rb.linearVelocity -= impulse * 0.5f;
                other.linearVelocity += impulse * 0.5f;
            }

          //表面張力
            Vector2 centerDir = other.position - rb.position;

            rb.AddForce(centerDir * surfaceTension * q * 0.1f);
        }
    }
}
