using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public bool canShoot; 
    public float powerUpDuration = 5;
    public float powerUpTimer = 0;

    public Text coinText;
    int coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootPowerUp();
    }

    public void GameOver()
    {
       isGameOver = true;

       //Llamar función de forma normal
       //LoadScene();

       //Invocar la función después de 2.5 segundos
       //Invoke("LoadScene", 2.5f);

       //Llamamos la corutina LoadScene
       StartCoroutine("LoadScene");
    }

    /*void LoadScene()
    {
       SceneManager.LoadScene(2);
    }*/

    IEnumerator LoadScene()
    {
        //Esto para lo corutina durante 2.5 segundos
        yield return new WaitForSeconds(2.5f);
        
        SceneManager.LoadScene(2);
    }

    public void AddCoin()
    {
        coins++;
        coinText.text = coins.ToString();
    }

    void ShootPowerUp()
    {
        if(canShoot)
        {
            if(powerUpTimer <= powerUpDuration)
            {
                powerUpTimer += Time.deltaTime;
            }
            else 
            {
                canShoot = false;
                powerUpTimer = 0;
            }
        }
    }


}
