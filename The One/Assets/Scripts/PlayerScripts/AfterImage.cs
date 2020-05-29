using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{

    [SerializeField]
    private float activeTime = 0.1f;  // tempo para ativar
    private float timeActivated; // tempo ativado
    private float alpha; //
    [SerializeField]
    private float alphaSet = 0.8f; // enable game object
    private float alphaMultiplier = 0.85f; // decrease alpha over the time (the smaller the number the faster the sprite will fade)

    private Transform player;

    private SpriteRenderer SR;
    private SpriteRenderer playerSR;

    private Color color;


    private void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        SR.sprite = playerSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1f, 1f, 1f, alpha);
        SR.color = color;

        if(Time.time >= (timeActivated + activeTime ))
        {
            PlayerAterImagePool.Instace.AddToPool(gameObject);
        }
    }



}
