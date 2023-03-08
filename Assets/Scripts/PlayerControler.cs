using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    int playerHealth = 3;
    float playerSpeed = 5.5f;
    public float jumpForce = 10f;
    string texto = "Hello World";
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor; 
    public Animator anim;
    public Text coinText;
    int contMonedas;
    float horizontal; 
    CoinManager coinManager;
    BanderaManager banderaManager;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        contMonedas= 0;
        playerHealth= 10;
        Debug.Log("Hello World");   
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        //transform.position += new Vector3 (horizontal, 0, 0) * playerSpeed * Time.deltaTime; 

        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("IsRunning", true);
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CoinCollision") 
        {
            CoinManager coinManager = collision.gameObject.GetComponent<CoinManager>();
            coinManager.DestruccionMoneda();
            coinText.text= "coin" + contMonedas;
        }

        if (collision.gameObject.tag == "BanderaCollision") 
        {
            BanderaManager banderaManager = collision.gameObject.GetComponent<BanderaManager>();
            banderaManager.BanderaTocada();
        }
    }
}
