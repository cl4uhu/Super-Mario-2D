using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanderaManager : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SFXManager sfxManager;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    
    public void BanderaTocada()
    {
        boxCollider.enabled = false; 
        sfxManager.BanderaManager();
        soundManager.StopBGM(); 
    }
}
