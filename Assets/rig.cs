using System.Collections.Generic;
using UnityEngine;

public class ViscosityAllInOne : MonoBehaviour
{
    class Particle
    {
        public Vector2 pos;
        public Vector2 vel;
        public GameObject obj;
        public SpriteRenderer sr;
    }

    public GameObject particlePrefab;

    public int particleCount = 50;

    public float R = 0.5f;
    public float SIGMA = 0.1f;
    public float DT = 0.01f;
    public float MAX_SPEED = 5f;

    List<Particle> particles = new List<Particle>();

    void Start()
    {
        for (int i = 0; i < particleCount; i++)
        {
            GameObject o = Instantiate(particlePrefab);

            o.transform.parent = transform;

            Vector2 pos = new Vector2(
                Random.Range(-2f, 2f),
                Random.Range(-2f, 2f)
            );

            o.transform.position = pos;

            Particle p = new Particle();
            p.pos = pos;
            p.vel = Random.insideUnitCircle * 5f;
            p.obj = o;
            p.sr = o.GetComponent<SpriteRenderer>();

            particles.Add(p);
        }
    }

    void Update()
    {
        ApplyViscosity();

        foreach (Particle p in particles)
        {
            // 位置更新
            p.pos += p.vel * DT;
            p.obj.transform.position = p.pos;

            // 速度制限
            if (p.vel.magnitude > MAX_SPEED)
                p.vel = p.vel.normalized * MAX_SPEED;

            // ✅ 色で可視化
            float speed = p.vel.magnitude;
            float t = Mathf.Clamp01(speed / MAX_SPEED);

            if (p.sr != null)
                p.sr.color = Color.Lerp(Color.blue, Color.red, t);
        }
    }

    void ApplyViscosity()
    {
        int count = particles.Count;

        for (int i = 0; i < count; i++)
        {
            Particle p = particles[i];

            for (int j = i + 1; j < count; j++)
            {
                Particle n = particles[j];

                Vector2 dir = n.pos - p.pos;
                float dist = dir.magnitude;

                if (dist >= R || dist == 0f) continue;

                Vector2 normal = dir / dist;
                float q = dist / R;

                float u = Vector2.Dot(p.vel - n.vel, normal);

                if (u > 0)
                {
                    Vector2 impulse = (1 - q) * SIGMA * u * normal;

                    // ✅ 対称更新
                    p.vel -= impulse * 0.5f;
                    n.vel += impulse * 0.5f;
                }
            }
        }
    }
}
