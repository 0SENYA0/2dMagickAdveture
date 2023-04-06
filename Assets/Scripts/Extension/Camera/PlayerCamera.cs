using UnityEngine;
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private PlayerPresenter _playerController;

    private void Update() =>
        transform.position = new Vector3(_playerController.transform.position.x, _playerController.transform.position.y + 5, -15);
}
