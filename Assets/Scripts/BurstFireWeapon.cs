using System.Collections;
using UnityEngine;

public class
    BurstFireWeapon : WeaponBase // his line defines the BurstFireWeapon class, which inherits from the WeaponBase class.
                                 // This means that the BurstFireWeapon class will inherit the properties and methods defined in the WeaponBase class
{
    [SerializeField] private int burstCount; // declares a serialized integer variable named burstCount. The reason we use 'int' for burstcount is because it can only be an whole number.
    // Which means you cant have like a fractional amount of 'bullets' it has to be whole.

    [SerializeField] private Rigidbody myBullet; //reference the prefab for the projectile
    [SerializeField] private float force; // Define the force variable for the BurstFireWeapon

 
    [SerializeField] private AudioSource gunshotAudioSource;

    [SerializeField] private float recoilStrength = 2.0f;

    public int BurstCount => burstCount; //FOR UI

    protected override void Attack(float percent) // overrides the Attack method inherited from the base class. It takes a percent argument, which can be used to determine the force of the shots
    {
        Debug.Log("BurstFireWeapon Attack method called. Percent: " +
                  percent); // DEBUGGING indicated the attack method has been called + percent
        print("My burst-firing weapon attacked: " + percent); //same shit, weapon has been fire + percent



        for (int i = 0; i < burstCount; i++) // this starts a 'for' loop that repeats from 0 to burstCount - 1. It controls the number of shots in a burst
        {
            FireShot(percent); // Inside the loop, this line calls the FireShot method to fire a single shot.


        }
        // Play shooting sound
        gunshotAudioSource.Play();


    }


    private void FireShot(float percent)
    {
        Ray camRay = InputManager.GetCameraRay();
        Rigidbody rb = Instantiate(myBullet, camRay.origin, transform.rotation);

        // Play shooting sound
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