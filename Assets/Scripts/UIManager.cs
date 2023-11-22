using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text weaponStatsText;
    [SerializeField] private WeaponBase currentWeapon;



    private void Start()
    {
        // Set the initial weapon
        SetWeapon(currentWeapon);
    }

    public void SetWeapon(WeaponBase weapon)
    {
        currentWeapon = weapon;
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
                               $"Is Fully Auto: {currentWeapon.GetIsFullyAuto()}";


            if (currentWeapon is BurstFireWeapon burstWeapon)
            {
                statsText += $"\nBurst Count: {burstWeapon.BurstCount}";
            }

            weaponStatsText.text = statsText;
        }
    }



}