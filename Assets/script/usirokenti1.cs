using UnityEngine;
using UnityEngine.SceneManagement;
using static nomal;

public class usirokenti1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;  // Å© 2âÒñ⁄à»ç~ñ≥éã
        triggered = true;

        string name = SceneManager.GetActiveScene().name;

        if (name == "nomal")
        {
            Debug.Log("OK");
            GlobalVariables.score += 1;

            if (GlobalVariables.score == 8)
            {
                SceneManager.LoadScene("goal");
            }
            else
            {
                mapselect();
            }
        }
        else
        {
            Debug.Log("NO");
            GlobalVariables.score = 0;
            mapselect();
        }
    }

    public void mapselect()
    {

        int map = Random.Range(0, 2);
        Debug.Log(map);
        if (map == 0)
        {
            int map2 = Random.Range(0, 6);
            if (map2 == 0) SceneManager.LoadScene("ihen1");
            if (map2 == 1) SceneManager.LoadScene("ihen2");
            if (map2 == 2) SceneManager.LoadScene("ihen3");
            if (map2 == 3) SceneManager.LoadScene("ihen4");
            if (map2 == 4) SceneManager.LoadScene("ihen5");
            if (map2 == 5) SceneManager.LoadScene("ihen6");

        }
        else
        {
            SceneManager.LoadScene("nomal");
        }
    }
}
