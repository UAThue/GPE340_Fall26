using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHealthBar : UIElement
{
    public Image healthBarImage;
    public TextMeshProUGUI healthBarText;
    public Health healthTarget; // This is the health component this UI element will subscribe to

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Subscribe to the player's Health's OnTakeDamage function!
        // This way, we run whenever they take damage!
       if (healthTarget != null)
        {
            SubscribeToHealthComponent(healthTarget);
            UpdateValue(healthTarget.GetPercentage());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubscribeToHealthComponent(Health healthComponent)
    {
        if (healthComponent != null)
        {
            healthComponent.OnTakeDamage.AddListener(() => UpdateValue(healthComponent.GetPercentage()));
        }
        else
        {
            Debug.Log("ERROR: No health component");
        }
    }

    public override void UpdateValue(float newValuePercent)
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = newValuePercent;
        }
        if (healthBarText != null)
        {
            healthBarText.text = DisplayPercent(newValuePercent) + "%";
        }
    }

    public float DisplayPercent( float realPercent )
    {
        if (realPercent > 0.98) return 100;
        if (realPercent < 0.1) return 1;
        return Mathf.Floor(realPercent * 100);
    }


}
