using UnityEngine;
[RequireComponent (typeof(Weapon))]
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
    [Header("Weapon Accuracy")]
    [Range(0.0f, 1.0f)] public float accuracy;
    [Range(0.0f, 45.0f)] public float maxAccuracyDelta;

    public void Shoot()
    {
        // Create a variable to hold our raycast hit data
        RaycastHit hit;

        // Instantiate our LaserBeam
        GameObject temp = Instantiate<GameObject>(laserBeamPrefab, transform.position, transform.rotation);
        // Make it a child of the firepoint
        temp.transform.parent = firepoint;

        // FIND OUR NEW DIRECTION TO FIRE, BASED ON OUR ACCURACY SYSTEM
        // Store the direction we shoot without the accuracy system
        Vector3 newFireDirection = firepoint.forward;

        // Find the number of degrees we "missed by" due to accuracy
        float accuracyPercent = Random.Range(0.0f, 1 - accuracy);
        float accuracyRotationDegrees = Mathf.Lerp(-maxAccuracyDelta, maxAccuracyDelta, accuracyPercent);

        // Get the roation change based on our accuracy
        Quaternion accuracyFireDelta = Quaternion.Euler(0, accuracyRotationDegrees, 0);

        // Multiply by the rotation from inaccuacy to set new rotation value
        // (Note that multiplication between a Quaternion and Vector is not commutative. The order matters!)
        newFireDirection = accuracyFireDelta * newFireDirection;

        // Draw the Laser
        LaserBeam theBeam = temp.GetComponent<LaserBeam>();

        // Set most of the laser data
        theBeam.color = laserData.color;
        theBeam.width = laserData.width;
        theBeam.startPoint = firepoint.position;
        theBeam.endPoint = firepoint.position + (newFireDirection * fireDistance);
        theBeam.lifespan = laserData.lifespan;

        // Do the Raycast
        if (Physics.Raycast(firepoint.position, newFireDirection, out hit, fireDistance))
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
