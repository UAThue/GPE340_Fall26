using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHealthCircle : UIElement
{
    public Image healthBarImage;
    public TextMeshProUGUI healthBarText;

    public override void UpdateValue(float newValue)
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = newValue;
        }
        if (healthBarText != null)
        {
            healthBarText.text = newValue + "%";
        }
    }
}
