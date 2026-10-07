using UnityEngine;
using UnityEngine.Events;

public class GA_Autofire : GameAction
{
    public bool isShooting;
    public float secondsPerShot;
    public UnityEvent OnShoot;
    private float lastShotTime;

    public void Start()
    {
        // Pretend we just shot the gun -- so we DO NOT need to delay before shooting again
        lastShotTime = Time.time - secondsPerShot;
    }

    public void Update()
    {
        if (isShooting)
        {
            if (Time.time >= lastShotTime + secondsPerShot)
            {
                OnShoot.Invoke();
                lastShotTime = Time.time;
            }
        }
    }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    public void ToggleShooting()
    {
        isShooting = !isShooting;
    }
}
