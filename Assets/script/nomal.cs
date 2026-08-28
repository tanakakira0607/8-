using UnityEditor;
using UnityEngine;

public class nomal : MonoBehaviour
{


    public GameObject exit0;
    public GameObject exit1;
    public GameObject exit2;
    public GameObject exit3;
    public GameObject exit4;
    public GameObject exit5;
    public GameObject exit6;
    public GameObject exit7;
    public GameObject exit8;

    void ShowExit(int index)
    {
        exit0.SetActive(false);
        exit1.SetActive(false);
        exit2.SetActive(false);
        exit3.SetActive(false);
        exit4.SetActive(false);
        exit5.SetActive(false);
        exit6.SetActive(false);
        exit7.SetActive(false);
        exit8.SetActive(false);

        if (index == 0) exit0.SetActive(true);
        if (index == 1) exit1.SetActive(true);
        if (index == 2) exit2.SetActive(true);

        if (index == 3) exit3.SetActive(true);
        if (index == 4) exit4.SetActive(true);
        if (index == 5) exit5.SetActive(true);

        if (index == 6) exit6.SetActive(true);
        if (index == 7) exit7.SetActive(true);
        if (index == 8) exit8.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        Debug.Log("åªç›ÇÕ " + GlobalVariables.score);
        ShowExit(GlobalVariables.score);




    }
    public static class GlobalVariables
    {
        public static int score = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }





}
