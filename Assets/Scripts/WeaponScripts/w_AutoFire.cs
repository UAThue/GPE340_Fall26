using UnityEngine;
using UnityEngine.Events;

public class w_AutoFire : MonoBehaviour
{
    public UnityEvent OnShoot;
    private bool isShooting;
    public float shootRate;

    void Update()
    {
        if (isShooting)
        {
            // TODO: Check if it is time to shoot, if so, then shoot:
            OnShoot.Invoke();
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

   


}
