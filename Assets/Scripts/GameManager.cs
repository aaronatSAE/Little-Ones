using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private GameObject boblin;
    [SerializeField] private Bobling boblingPrefab;
    [SerializeField] private Robling roblingPrefab;
    [SerializeField] private CharacterSpawner characterSpawner;

    [Header("Boblings")]
    [SerializeField] private int boblingsToSpawnAtStart;
    [SerializeField] private List<Bobling> boblings = new List<Bobling>();

    [Header("Roblings")]
    [SerializeField] private int roblingsToSpawnAtStart;
    [SerializeField] private List<Robling> roblings = new List<Robling>();

    [Header("Roblin Spawn Functionality")]
    [SerializeField] private float roblingSpawnTimer;
    [SerializeField] private float roblingSpawnTimerReset;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;

        // Spawn boblings at the start of the game.
        for (int i = 0; i < boblingsToSpawnAtStart; i++)
        {
            // Instantiate a new bobling.
            Bobling newBobling = Instantiate(boblingPrefab, boblin.transform.position, Quaternion.identity);

            // Add it to our collective list.
            boblings.Add(newBobling);
        }

        // Spawn roblings at the start of the game.
        for (int i = 0; i < roblingsToSpawnAtStart; i++)
        {
            // Instantiate a new robling.
            Robling newRobling = Instantiate(roblingPrefab, boblin.transform.position, Quaternion.identity);

            // Add it to our collective list.
            roblings.Add(newRobling);
        }
    }

    private void Update()
    {
        roblingSpawnTimer -= Time.deltaTime;

        if (roblingSpawnTimer < 0)
        {
            characterSpawner.SpawnNewCharacter(roblingPrefab.gameObject, Vector2.one * 5f, 1);
            roblingSpawnTimer = roblingSpawnTimerReset;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(uiPanel.activeSelf == true)
            {
                uiPanel.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
            Bobling closestBobling = GetClosestBoblingFromThisPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            closestBobling.mover.SetDestination(new Vector3(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0));
        }
    }

    // This doesn't work yet... oh well! (:
    private Bobling GetClosestBoblingFromThisPosition(Vector2 referencePosition)
    {
        //Bobling closestBobling = null;
        //float distanceToClosestBobling = Mathf.Infinity;

        //foreach(Bobling bobling in boblings)
        //{
        //    if(Vector2.Distance(bobling.transform.position, referencePosition) < distanceToClosestBobling)
        //    {
        //        closestBobling = bobling;
        //    }
        //}

        //return closestBobling;

        return boblings[Random.Range(0, boblings.Count)];
    }

    public void HitBoblin()
    {
        Debug.Log("Boblin has been hit! Ow!");
    }

    public void HitBobling(Vector3 hitPosition)
    {
        characterSpawner.SpawnNewCharacter(boblingPrefab.gameObject, hitPosition, 1);
    }

    public void AddBoblingToListOfBoblings(Bobling newBobling)
    {
        boblings.Add(newBobling);
    }

    public void AddRoblingToListOfRoblings(Robling newRobling)
    {
        roblings.Add(newRobling);
    }
}
