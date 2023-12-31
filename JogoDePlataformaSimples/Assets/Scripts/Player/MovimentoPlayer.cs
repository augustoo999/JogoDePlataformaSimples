using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MovimentoPlayer : MonoBehaviour
{
    public TextMeshProUGUI MoedaTxt;
    public float speed;
    private bool isGround = true;
    public Rigidbody2D rb;
    private float direction;
    public float ForcaPulo;
    [SerializeField]
    private string Reset;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Andar();
        Pulo();
    }

    public void Andar()
    {
        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

    }

    public void Pulo()
    {
        if (isGround && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * ForcaPulo;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
