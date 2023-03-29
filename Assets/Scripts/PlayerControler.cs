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
    //variable àra acceder al Animator
    public Animator anim;
    public Text coinText;
    int contMonedas;
    //variable para almacenar el input de movimiento
    float horizontal; 
    CoinManager coinManager;
    BanderaManager banderaManager;
    GameManager gameManager;
    //variable para el prefab
    public GameObject bulletPrefab;
    //variable para la posición desde donde se dispara el prefab
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        contMonedas= 0;
        playerHealth= 10;
        Debug.Log("Hello World");   
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameOver == false)
        {
            horizontal = Input.GetAxis("Horizontal");

        //transform.position += new Vector3 (horizontal, 0, 0) * playerSpeed * Time.deltaTime; 

        if(horizontal < 0)
        {
            //spriteRenderer.flipX = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("IsRunning", true);
        }
        else if (horizontal > 0)
        {
            //spriteRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
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

        if(Input.GetKeyDown(KeyCode.F) && gameManager.canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            gameManager.AddCoin();
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "PowerUp")
        {
            gameManager.canShoot = true;
            Destroy(collider.gameObject);
        }
    }
}
