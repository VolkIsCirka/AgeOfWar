using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsCollision : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void OnSpawned(Unit unit)
    {
        foreach(Unit unitInList in _spawner.Units)
        {
 //           Physics2D.IgnoreCollision();
        }
    }
}
