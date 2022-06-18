using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Unit _prefab;
    [SerializeField] private UnitsAll _units;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _units.TakeUnit(_spawner.Spawn(_prefab, Team.Player));
        }
    }
}
