using UnityEngine;


public class PlayerLightController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private void Update()
    {
        transform.position = new Vector3(_playerController.transform.position.x, _playerController.transform.position.y + 5, -5);
    }
}
