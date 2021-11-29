using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Permainan() { SceneManager.LoadScene("SampleScene"); }
    public void KembalikeMenu() { SceneManager.LoadScene("MainMenu"); }
    public void CaraBermain() { SceneManager.LoadScene("CaraBermain"); }
    public void ExitGame() { Application.Quit(); }
}
