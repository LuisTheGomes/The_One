using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerMovement;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Posição actual da câmera
        Vector3 temp = transform.position;

        // Posição x da câmera é igual á posição x do player
        temp.x = playerMovement.position.x;
        temp.y = playerMovement.position.y;

        temp.x += offset;

        // Posição temporária da câmera é igual á posição actual da câmera
        transform.position = temp;

    }
}
