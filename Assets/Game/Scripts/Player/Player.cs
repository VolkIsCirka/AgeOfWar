using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Unit _prefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _spawner.Spawn(_prefab, Team.Player);
        }
    }
}
