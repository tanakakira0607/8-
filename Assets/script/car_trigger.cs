using UnityEngine;

public class PassThroughCar : MonoBehaviour
{
    private Collider2D myCollider;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("car"))
        {
            Physics2D.IgnoreCollision(
                other.GetComponent<Collider2D>(),
                myCollider,
                true
            );
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("car"))
        {
            Physics2D.IgnoreCollision(
                other.GetComponent<Collider2D>(),
                myCollider,
                false
            );
        }
    }
}