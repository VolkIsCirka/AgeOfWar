using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public bool IsFree => _weapon.IsFree;

    public float DistanceForAttack => _weapon.DistanceForAttack;

    public void TakeEnemy(Unit unit)
    {
        if (IsFree)
        {
            _weapon.NewTarget(unit);
        }
    }
}
