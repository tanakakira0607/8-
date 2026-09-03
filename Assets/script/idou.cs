using UnityEngine;
public class idoutesy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    Rigidbody2D rb;
    float speed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }



    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed = -5f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            speed = 5f;
        }
        else
        {
            speed = 0f;
        }

        rb.linearVelocity = new Vector2(speed,rb.linearVelocity.y);
    }


}
