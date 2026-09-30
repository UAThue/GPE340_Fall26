using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public float explosionSize;
    public float explosionForce;
    public float explosionDamage;
    public GameObject particleEffect;
    public AudioClip explosionSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Do any initialization here
    }

    public void Explode()
    {
        Explode(explosionSize, explosionForce, explosionDamage);
    }

    public void Explode(float explosionSize, float explosionForce, float explosionDamage)
    {
        // Debug
        Debug.Log("BOOOM!");

        //TODO: Instantiate our particle effect
        //TODO: Play out sound

        // Grab all the objects around this object
        Collider[] targets = Physics.OverlapSphere(transform.position, explosionSize);

        // For each of those objects
        foreach (Collider target in targets)
        {
            // If they have a rigidbody
            Rigidbody rb = target.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Apply force in the direction AWAY from the object (from this object TO target)
                Vector3 explosionVector = target.transform.position - this.transform.position;
                explosionVector.Normalize();
                rb.AddForce(explosionVector * explosionForce, ForceMode.Force);
            }

            //TODO: If those objects have a health component
            //TODO:    Do damage to them

        }
    }
}
