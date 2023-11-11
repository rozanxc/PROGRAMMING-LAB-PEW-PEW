using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileWeapon : WeaponBase
{
    [SerializeField] private Rigidbody myBullet;
    [SerializeField] private Rigidbody myBullet2;
    [SerializeField] protected float force = 50;
    protected override void Attack(float percent)
    {
        Debug.Log("Attack method called. Percent: " + percent); //DEBUGGING
        print("My weapon attacked: " + percent);
        
        Ray camRay = InputManager.GetCameraRay();
        Rigidbody rb = Instantiate(percent>0.5f?myBullet2:myBullet, camRay.origin, transform.rotation);
        rb.AddForce(Mathf.Max(percent, 0.1f) * force * camRay.direction, ForceMode.Impulse);
    }
}
