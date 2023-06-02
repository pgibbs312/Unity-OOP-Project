using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] PickUpSpawn[] pickUps;
    [Range(0, 1)]
    [SerializeField] float pickupProbability;
    List<Pickup> pickupPool = new List<Pickup>();
    Pickup chosenPickup;
    // Start is called before the first frame update
    void Start()
    {
        foreach (PickUpSpawn spawn in pickUps)
        {
            for (int i = 0; i < spawn.spawnWeight; i++)
            {
                pickupPool.Add(spawn.pickup);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPickup(Vector2 position)
    {
        if (pickupPool.Count <= 0)
        {
            return;
        }
        if (Random.Range(0f, 1f) < pickupProbability)
        {
            chosenPickup = pickupPool[Random.Range(0, pickupPool.Count)];
            Instantiate(chosenPickup, position, Quaternion.identity);
        }
    }
}
[System.Serializable]
public struct PickUpSpawn
{
    public Pickup pickup;
    public int  spawnWeight;
}
