using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobling : MonoBehaviour
{
    public Mover mover;
    [SerializeField] private Vector2 bounds = new Vector2(7.5f, 3f);

    private void Start()
    {
        mover.SetDestination(new Vector3(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y), 0));
    }
}
