using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    public string name;
    public int cost;
    public int damage;
}
