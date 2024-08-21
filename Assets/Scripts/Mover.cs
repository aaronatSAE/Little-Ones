using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speedInUnitsPerSecond;
    [SerializeField] private GameObject gameObjectToMoveTowards;
    [SerializeField] private Vector3 positionToMoveTowards;

    //[SerializeField] private Vector2 bounds = new Vector2(7.5f, 3f);
    //[SerializeField] private Vector2 boundedPosition = Vector2.zero;

    //private void Start()
    //{
    //    SetDestination(new Vector3(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y), 0));
    //}

    private void Update()
    {
        // If we have no target object or destination, don't do anything else here.
        if (gameObjectToMoveTowards == null && positionToMoveTowards == Vector3.one * 999) return;

        Vector3 directionToTarget = Vector3.zero;

        // Get the direction towards the target we want to move towards.
        // ...a game object...
        if (gameObjectToMoveTowards != null)
        {
            directionToTarget = gameObjectToMoveTowards.transform.position - transform.position;
        }
        // ...or simply a destination.
        else
        {
            directionToTarget = positionToMoveTowards - transform.position;
        }

        // Normalize it so we can use it as direction.
        directionToTarget.Normalize();

        // Move towards the destination.
        transform.position += directionToTarget * speedInUnitsPerSecond * Time.deltaTime;

        // Keep the character within bounds.
        //if (transform.position.x > bounds.x) boundedPosition.x = bounds.x;
        //if (transform.position.x < -bounds.x) boundedPosition.x = -bounds.x;
        //if (transform.position.y > bounds.y) boundedPosition.y = bounds.y;
        //if (transform.position.y < -bounds.y) boundedPosition.y = -bounds.y;
        //transform.position = boundedPosition;
    }

    public void SetDestination(GameObject targetGameObject)
    {
        gameObjectToMoveTowards = targetGameObject;
    }

    public void SetDestination(Vector3 targetPosition)
    {
        positionToMoveTowards = targetPosition;
    }
}
