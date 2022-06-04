using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFinder : MonoBehaviour
{
    private Unit _i;
    private List<Unit> _units;

    public event Action<IReadOnlyList<Unit>> Found;
    public event Action<Unit> Lost;

    public IReadOnlyList<Unit> Units => _units;

    private void Awake()
    {
        _i = GetComponentInParent<Unit>();
        _units = new List<Unit>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Unit unit))
        {
            if(unit != _i)
            {
                _units.Add(unit);
                Found?.Invoke(_units);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Unit unit))
        {
            if(unit != _i)
            {
                _units.Remove(unit);
                Lost?.Invoke(unit);
            }
        }
    }
}
