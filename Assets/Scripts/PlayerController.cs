using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    bool Jumping = true;
    public Rigidbody2D rb;
    int Movement = 0;
    Animator anim;
    public int Nanas = 0;
    public Text TextTimer;
    public float Waktu;
    public GameObject CanvasKalah;
    public GameObject CanvasWin;
    float s;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        Data.score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-3, 0);
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("run", true);
            anim.SetBool("idle", false);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(3, 0);
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("run", true);
            anim.SetBool("idle", false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            anim.SetBool("jump", true);
            anim.SetBool("run", true);
            anim.SetBool("idle", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Idle();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Idle();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-3, 0);
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("slide", true);
            anim.SetBool("idle", false);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(3, 0);
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("slide", true);
            anim.SetBool("idle", false);
        }
        if (Data.score >= 10)
        {
            CanvasWin.SetActive(true);
            return;
        }
        
        s += Time.deltaTime;
        if (s >= 1 && Waktu!=0)
        {
                Waktu--;
                s = 0;
        }
        if (Waktu <= 0)
        {
            CanvasKalah.SetActive(true);
        }
        SetText();
        Moving();

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Jumping)
        {
            anim.ResetTrigger("jump");
            if (Movement == 0) anim.SetTrigger("idle");
            Jumping = false;
        }
    }

    public void MoveRight() { Movement = 2; }
    public void MoveLeft() { Movement = 1; }

    private void Moving()
    {
        if (Movement == 2)
        {
            if (!Jumping) anim.SetTrigger("run");
            transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (Movement == 1)
        {
            if (!Jumping) anim.SetTrigger("run");
            transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    public void Jump()
    {
        if (!Jumping)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
        }
    }
    public void Idle()
    {
        if (!Jumping)
        {
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.SetTrigger("idle");
        }
        Movement = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Nanas"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
    }
    void SetText()
    {
        int Menit = Mathf.FloorToInt(Waktu / 60);
        int Detik = Mathf.FloorToInt(Waktu % 60);
        TextTimer.text = Menit.ToString("00") + ":" + Detik.ToString("00");
    }
    public void SlideLeft()
    {
        rb.velocity = new Vector2(-3, 0);
        anim.SetBool("slide", true);
        transform.localScale = new Vector2(-1, 1);
    }
    public void SlideRight()
    {
        rb.velocity = new Vector2(3, 0);
        transform.localScale = new Vector2(1, 1);
        anim.SetBool("slide", true);
    }
}

