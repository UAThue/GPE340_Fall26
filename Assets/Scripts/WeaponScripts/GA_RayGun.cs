using UnityEngine;

public class GA_RayGun : GameAction
{
    [Tooltip("Where the ray originates from.")]
    public Transform firepoint;
    [Tooltip("How far the ray fires.")]
    public float fireDistance;
    [Tooltip("How much damage the ray does.")]
    public float damageDone;
    [Tooltip("The visuals for the ray.")]
    public LaserVisuals laserData;
    public GameObject laserBeamPrefab;

    public void Shoot()
    {
        // Create a variable to hold our raycast hit data
        RaycastHit hit;

        // Instantiate our LaserBeam
        GameObject temp = Instantiate<GameObject>(laserBeamPrefab, transform.position, transform.rotation);
        LaserBeam theBeam = temp.GetComponent<LaserBeam>();

        // Set most of the laser data
        theBeam.color = laserData.color;
        theBeam.width = laserData.width;
        theBeam.startPoint = firepoint.position;
        theBeam.endPoint = firepoint.position + (firepoint.forward * fireDistance);
        theBeam.lifespan = laserData.lifespan;

        // Do the Raycast
        if (Physics.Raycast(firepoint.position, firepoint.forward, out hit, fireDistance))
        {
            // If we hit, and the other object has a Health component
            Health otherHealth = hit.collider.gameObject.GetComponent<Health>();
            if (otherHealth != null)
            {
                // Tell it to take damage!
                otherHealth.TakeDamage(damageDone);
            }

            // Health or no health, limit our laserbeam endpoint
            theBeam.endPoint = hit.point;
        }
    }
}

[System.Serializable]
public class LaserVisuals
{
    public Color color = Color.white;
    public float width = 0.5f;
    public float lifespan = 0.1f;
}
