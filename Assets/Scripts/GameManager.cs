using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
       isGameOver = true;

       //Llamar función de forma normal
       //LoadScene();

       //Invocar la función después de 2.5 segundos
       Invoke("LoadScene", 2.5f);
    }

    void LoadScene()
    {
       SceneManager.LoadScene(2);
    }
}
