using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text weaponStatsText;
    [SerializeField] private WeaponBase currentWeapon;
    [SerializeField] private EWeaponType currentWeaponType;

    private void Start()
    {
        // Set the initial weapon
        SetWeapon(currentWeapon, currentWeaponType);
    }

    public void SetWeapon(WeaponBase weapon, EWeaponType weaponType)
    {
        currentWeapon = weapon;
        currentWeaponType = weaponType;
        UpdateWeaponStats();
    }

    private void UpdateWeaponStats()
    {
        if (currentWeapon != null && weaponStatsText != null)
        {
            string statsText = $"<color=red><b>Weapon Stats</b></color>\n" +
                               $"Time Between Attacks: {currentWeapon.GetTimeBetweenAttacks()}\n" +
                               $"Charge Up Time: {currentWeapon.GetChargeUpTime()}\n" +
                               $"Min Charge Percent: {currentWeapon.GetMinChargePercent()}\n" +
                               $"Is Fully Auto: {currentWeapon.GetIsFullyAuto()}\n" +
                               $"Weapon Type: {currentWeaponType}";

            if (currentWeapon is BurstFireWeapon burstWeapon)
            {
                statsText += $"\nBurst Count: {burstWeapon.BurstCount}";
            }

            weaponStatsText.text = statsText;
        }
    }
}
