using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rBody2D;

    public float bulletSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
       rBody2D = GetComponent<Rigidbody2D>();

       rBody2D.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);  
    }
}
