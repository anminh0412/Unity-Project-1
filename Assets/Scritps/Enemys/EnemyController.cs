using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Despawner despawner;
    private void Awake()
    {
        this.despawner = GetComponent<Despawner>();
    }
}
