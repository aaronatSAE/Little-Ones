using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Robling : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private Mover mover;

    private void Start()
    {
        mover.SetDestination(Vector3.zero);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Boblin")
        {
            gameManager.HitBoblin();
            Destroy(gameObject);
        }
        else if(collision.gameObject.name.Contains("Bobling"))
        {
            gameManager.HitBobling(transform.position);
            Destroy(gameObject);
        }
    }
}
