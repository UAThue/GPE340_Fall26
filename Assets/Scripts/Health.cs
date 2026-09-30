using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Default Data")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [Header("Events")]
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage( float damageDone )
    {
        // Debug 
        Debug.Log("Ouch!");

        // Subtract damage from health
        currentHealth -= damageDone;

        //  Clamp health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        //  Check for death
        if ( currentHealth <= 0)
        {
            Die(); 
        }

        // Fire the "OnTakeDamage" Event, so any function subscribed to this event runs
        OnTakeDamage.Invoke();
    }

    public void Die()
    {
        // Do whatever every death does
        Debug.Log(gameObject.name + " has died. ");
        // Fire the "OnDeath" Event, so that any function subscribed to this event runs
        OnDeath.Invoke();
    }


}
