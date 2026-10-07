using UnityEngine;

public class TestRaygun : MonoBehaviour
{
    public Weapon gun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun.OnPrimaryFireStart.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            gun.OnPrimaryFireEnd.Invoke();
        }
    }
}
