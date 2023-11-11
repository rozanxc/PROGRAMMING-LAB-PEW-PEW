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



    protected override void Attack(float percent) // overrides the Attack method inherited from the base class. It takes a percent argument, which can be used to determine the force of the shots
    {
        Debug.Log("BurstFireWeapon Attack method called. Percent: " +
                  percent); // DEBUGGING indicated the attack method has been called + percent
        print("My burst-firing weapon attacked: " + percent); //same shit, weapon has been fire + percent

        for (int i = 0; i < burstCount; i++) // this starts a 'for' loop that repeats from 0 to burstCount - 1. It controls the number of shots in a burst
        {
            FireShot(percent); // Inside the loop, this line calls the FireShot method to fire a single shot.

        }
    }

    private void FireShot(float percent) // method that fires the shot.

    {   //GOT THIS FROM PROJECTWEAPON
        Ray camRay = InputManager.GetCameraRay();
        Rigidbody rb = Instantiate(myBullet, camRay.origin, transform.rotation);
        rb.AddForce(Mathf.Max(percent, 0.1f) * force * camRay.direction, ForceMode.Impulse);
    }
}


//CREATE A NEW BULLET 