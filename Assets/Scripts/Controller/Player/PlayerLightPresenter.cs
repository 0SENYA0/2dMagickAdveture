using UnityEngine;


public class PlayerLightPresenter : MonoBehaviour
{
    [SerializeField] private PlayerPresenter _playerPresenter;

    private void Update()
    {
        transform.position = new Vector3(_playerPresenter.transform.position.x, _playerPresenter.transform.position.y + 5, -5);
    }
}
