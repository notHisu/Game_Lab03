using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Explosion Prefab
    public GameObject explosionPrefab;
    void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

}
