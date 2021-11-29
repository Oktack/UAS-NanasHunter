using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    //public Transform Bg1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        
        //transform.position = new Vector3(player.position.x, player.transform.position.y, transform.position.z);
     
        transform.position = new Vector3(player.position.x, player.position.y, -20);
    }
}
