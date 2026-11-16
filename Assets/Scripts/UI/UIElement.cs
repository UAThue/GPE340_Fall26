using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class UIElement : MonoBehaviour
{
    public abstract void UpdateValue(float newValue);
}
