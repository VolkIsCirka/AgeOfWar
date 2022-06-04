using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]

public class UnitAttacker : MonoBehaviour
{
    [SerializeField] private UnitFinder _finder;
    [SerializeField] private Weapon _weapon;

    private Unit _i;

    private void Awake()
    {
        _i = GetComponent<Unit>();
    }

    private void OnEnable()
    {
        _finder.Found += OnFound;
        _finder.Lost += OnLost;
    }

    private void OnDisable()
    {
        _finder.Found -= OnFound;
        _finder.Lost -= OnLost;
    }

    private void OnFound(IReadOnlyList<Unit> units)
    {
        TryFindNewTarget(units);
    }

    private void OnLost(Unit unit)
    {
        TryFindNewTarget(_finder.Units);
    }

    private bool TryFindNewTarget(IReadOnlyList<Unit> units)
    {
        foreach (Unit unit in units)
        {
            if (unit.Team != _i.Team && _weapon.IsFree)
            {
                _weapon.NewTarget(unit);
                return true;
            }
        }
        return false;
    }
}
