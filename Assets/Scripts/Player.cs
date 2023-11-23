using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum EWeaponType
{
    BurstFire,
    Projectile
}

public class Player : MonoBehaviour
{
    [SerializeField] private WeaponBase[] weapons;
    [SerializeField] private UIManager uiManager;

    private int currentWeaponIndex = 0;
    private EWeaponType currentWeaponType = EWeaponType.Projectile;

    private bool weaponShootToggle;

    private void Start()
    {
        InputManager.Init(this);
        InputManager.EnableInGame();
        uiManager.SetWeapon(weapons[currentWeaponIndex], currentWeaponType);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeaponType(EWeaponType.BurstFire);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeaponType(EWeaponType.Projectile);
        }
    }

    private void ChangeWeaponType(EWeaponType newWeaponType)
    {
        currentWeaponType = newWeaponType;
        weapons[currentWeaponIndex].StopShooting();

        switch (currentWeaponType)
        {
            case EWeaponType.BurstFire:
                currentWeaponIndex = 0;
                break;
            case EWeaponType.Projectile:
                currentWeaponIndex = 1;
                break;
                // No need for a case for the removed third option
        }

        uiManager.SetWeapon(weapons[currentWeaponIndex], currentWeaponType);
    }

    public void Shoot()
    {
        print("I shot: " + InputManager.GetCameraRay());
        weaponShootToggle = !weaponShootToggle;

        if (weaponShootToggle)
            weapons[currentWeaponIndex].StartShooting();
        else
            weapons[currentWeaponIndex].StopShooting();
    }
}
