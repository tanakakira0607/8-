using UnityEngine;

public class sm : MonoBehaviour
{
    public GameObject Object;
    // Update is called once per frame
    void Update()
    {
        Instantiate(Object);
    }
}
