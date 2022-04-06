using UnityEngine;

public class WeaponCanvas : MonoBehaviour
{
    [SerializeField] WeaponData newWeapon; 

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ManagerGame.instancia.UpdateUI(newWeapon);
        }
    }
}
