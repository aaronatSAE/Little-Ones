using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private List<GameObject> spawnLocations = new List<GameObject>();

    public void SpawnNewCharacter(GameObject prefabToSpawn, Vector3 positionToSpawn, int countToSpawn)
    {
        for (int i = 0; i < countToSpawn; i++)
        {
            // Instantiate a new character.
            GameObject newCharacter = Instantiate(prefabToSpawn, positionToSpawn, Quaternion.identity);

            // Add the spawned character to the appropriate list for...
            // ...boblings...
            Bobling newBobling;
            newCharacter.TryGetComponent(out newBobling);
            if (newBobling != null)
            {
                gameManager.AddBoblingToListOfBoblings(newBobling);
            }
            // ...or roblings!
            Robling newRobling;
            newCharacter.TryGetComponent(out newRobling);
            if (newRobling != null)
            {
                newRobling.transform.position = spawnLocations[Random.Range(0, spawnLocations.Count)].transform.position;
                newRobling.gameManager = gameManager;
                gameManager.AddRoblingToListOfRoblings(newRobling);
            }
        }
    }
}
