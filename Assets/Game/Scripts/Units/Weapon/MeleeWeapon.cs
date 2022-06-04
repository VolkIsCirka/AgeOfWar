using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    protected override void Attack(Unit unit)
    {
        unit.TakeDamage(Damage);
    }
}
