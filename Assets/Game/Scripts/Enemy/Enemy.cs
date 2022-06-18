using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Unit _prefab;
    [SerializeField] private UnitsAll _units;

    private float _timeBeforeSpawn;

    private void Awake()
    {
        _timeBeforeSpawn = _cooldown;
    }

    private void Update()
    {
        _timeBeforeSpawn = Mathf.Max(0, _timeBeforeSpawn - Time.deltaTime);

        if(_timeBeforeSpawn == 0)
        {
            _units.TakeUnit(_spawner.Spawn(_prefab, Team.PC));
            _timeBeforeSpawn = _cooldown;
        }
    }
}
