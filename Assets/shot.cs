using UnityEngine;

public class shot : MonoBehaviour
{
    public GameObject Object;

    float timer = 0f;
    float interval = 0.01f;

 

    public int maxCount = 100;
    private int count = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval && count < maxCount)
        {
            Instantiate(Object,
                new Vector3(5.49f, -3.21f, 0),
                Quaternion.identity);

            count++;
            timer = 0f;
        }
    }
}