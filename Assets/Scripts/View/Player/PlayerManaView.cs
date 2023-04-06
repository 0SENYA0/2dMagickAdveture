using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerManaView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetNewValue(int newValue) =>
        _image.fillAmount = (float)newValue / (float)100;
}
