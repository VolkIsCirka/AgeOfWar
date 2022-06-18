using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Spawner : MonoBehaviour
{
    [SerializeField] private float _offset;

    private List<Unit> _units;

    public IReadOnlyList<Unit> Units => _units;

    private void Awake()
    {
        _units = new List<Unit>();
    }

    public Unit Spawn(Unit prefab,Team team)
    {
        float offset = _offset;
        Unit unit = Instantiate(prefab, transform.position + new Vector3(offset, 0, 0), Quaternion.identity);
        unit.Init(team);
        Add(unit);
        return unit;
    }

    private void Add(Unit unit)
    {
        _units.Add(unit);
        unit.Died += OnDied;
    }

    private void OnDied(Unit unit)
    {
        unit.Died -= OnDied;
        _units.Remove(unit);
    }
}