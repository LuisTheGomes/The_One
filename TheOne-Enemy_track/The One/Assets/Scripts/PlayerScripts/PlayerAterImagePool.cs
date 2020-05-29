using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAterImagePool : MonoBehaviour
{
    [SerializeField]
    private GameObject afterImagePrefab;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static PlayerAterImagePool Instace { get; private set; }

    private void Awake()
    {
        Instace = this;
        GrowPool();
    }


    private void GrowPool() // Create more game objects for the pool 
    {
        for(int i = 0; i < 10; i++)
        {
            var instaceToAdd = Instantiate(afterImagePrefab);
            instaceToAdd.transform.SetParent(transform);
            AddToPool(instaceToAdd);

        }
    }

    public void AddToPool(GameObject instace)
    {
        instace.SetActive(false);
        availableObjects.Enqueue(instace);
    }
    
    public GameObject GetFromPool()
    {
        if(availableObjects.Count == 0)
        {
            GrowPool();
        }

        var instace = availableObjects.Dequeue();
        instace.SetActive(true);
        return instace;

    }
}
