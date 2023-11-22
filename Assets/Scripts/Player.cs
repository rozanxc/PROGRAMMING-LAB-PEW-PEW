using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private WeaponBase[] weapons;
    [SerializeField] private UIManager uiManager;

    private int currentWeaponIndex = 0;
    
    
    
    private bool weaponShootToggle;

    private void Start()
    {
        InputManager.Init(this);
        InputManager.EnableInGame();
        uiManager.SetWeapon(weapons[currentWeaponIndex]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CycleWeapon(-1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CycleWeapon(1);
        }
    }

    private void CycleWeapon(int direction)
    {
        weapons[currentWeaponIndex].StopShooting();
        currentWeaponIndex += direction;

        if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = weapons.Length - 1;
        }
        else if (currentWeaponIndex >= weapons.Length)
        {
            currentWeaponIndex = 0;
        }

        uiManager.SetWeapon(weapons[currentWeaponIndex]);
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
