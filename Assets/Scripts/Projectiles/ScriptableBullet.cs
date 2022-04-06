using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBullet", menuName = "Bullet")]
public class ScriptableBullet : ScriptableObject
{
    public int damage;
    public float speedMov;
}
