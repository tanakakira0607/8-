using UnityEngine;
using UnityEngine.SceneManagement;

public class teki : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    float speed = -30f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Å© Ç±ÇÍÇ™Ç»Ç¢Ç∆ÉGÉâÅ[Ç…Ç»ÇÈ
    }


    // Update is called once per frame
    void Update()
    {
        

        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("è’ìÀÇµÇ‹ÇµÇΩ");
        
        SceneManager.LoadScene("nomal");
    }
}
