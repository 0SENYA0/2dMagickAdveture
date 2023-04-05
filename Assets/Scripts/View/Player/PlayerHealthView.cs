using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Image _image;

    public void SetNewValue(int newValue) =>
        _image.fillAmount = (float)newValue / (float)100;
}
