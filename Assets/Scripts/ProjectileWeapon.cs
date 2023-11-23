using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileWeapon : WeaponBase
{
    [SerializeField] private Rigidbody myBullet;
    [SerializeField] private Rigidbody myBullet2;
    [SerializeField] protected float force = 50;

    [SerializeField] private AudioSource gunshotAudioSource;

    [SerializeField] private float recoilStrength = 2.0f;







    protected override void Attack(float percent)
    {
        Debug.Log("Attack method called. Percent: " + percent);
        print("My weapon attacked: " + percent);

        Ray camRay = InputManager.GetCameraRay();
        Rigidbody rb = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin, transform.rotation);

        //Play shooting sound
        gunshotAudioSource.Play();

        // Apply recoil force
        ApplyRecoilForce(rb, percent);

        rb.AddForce(Mathf.Max(percent, 0.1f) * force * camRay.direction, ForceMode.Impulse);
        
    }

    private void ApplyRecoilForce(Rigidbody rb, float percent)
    {
        // Example: Apply a recoil force in a random direction
        Vector3 recoilDirection = Random.onUnitSphere; // Random direction
        Vector3 recoilForce = recoilDirection * recoilStrength * percent;
        Debug.Log("Recoil Force: " + recoilForce);
        rb.AddForce(recoilForce, ForceMode.Impulse);
    }

}