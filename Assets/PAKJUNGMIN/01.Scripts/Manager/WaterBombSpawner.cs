using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBombSpawner : MonoBehaviour
{
    [SerializeField] WaterBomb waterBomb;
    [SerializeField] int size;
    [SerializeField] int capacity;
    private void Awake()
    {
        Manager.Pool.CreatePool(waterBomb, size, capacity);
        //CreatePool(prefab, 23, 200);
    }
}
