using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Text text;
    //public static int Nanas = 0;


    // Start is called before the first frame update
    void Start()
    {
       // text = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Text>().text = Data.score.ToString("0");
    }
    //void Update()
    //{
        //text.text = Nanas.ToString();

    //}

}
