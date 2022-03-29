using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class CoinBehaviour : MonoBehaviour
{



    Collider2D coinCollider;
    SpriteRenderer coinSpriteRenderer;
    AudioSource pickUpSound;

     const float coinCD = 50f;
    float CDTimer; 

 bool isGrabbed = false;


    // Start is called before the first frame update
    void Start()
    {
        coinCollider = GetComponent<Collider2D>();
        coinSpriteRenderer = GetComponent<SpriteRenderer>();
        pickUpSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(CDTimer > 0)
        {
            CDTimer -= Time.deltaTime;
        }


       else if(isGrabbed)
        {
            isGrabbed = false;
            Respawn();
        }
    }


    public void OnGrabbed()
    {
        CDTimer = coinCD;

        coinCollider.enabled = false;
        coinSpriteRenderer.enabled = false;
        isGrabbed = true;

        pickUpSound.Play();


    }

    void Respawn()//Reactiva la cereza
    {
        coinCollider.enabled = true;
        coinSpriteRenderer.enabled = true;
    }
}




