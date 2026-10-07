using UnityEngine;
using UnityEngine.Events;

public class GA_AmmoLimit : GameAction
{

    [SerializeField] private int ammo = 0;
    [SerializeField] private int ammoPerShot = 1;
    [SerializeField] private int maxAmmo = 9;
    public UnityEvent OnSuccess;
    public UnityEvent OnFail;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SubtractAmmo (int ammoToSubtract)
    {
        ammo -= ammoToSubtract;
        ammo = Mathf.Clamp(ammo, 0, maxAmmo);
    }

    public void AddAmmo(int ammoToAdd)
    {
        ammo += ammoToAdd;
        ammo = Mathf.Clamp(ammo, 0, maxAmmo);
    }

    public void TryToShoot()
    {
        if (ammo >= ammoPerShot)
        {
            ammo -= ammoPerShot;
            OnSuccess.Invoke();
        }
        else
        {
            OnFail.Invoke();
        }
    }
}
