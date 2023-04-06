using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPresenter : MonoBehaviour
{
    [SerializeField] private PlayerHealthPresenter _playerHealthPresenter;
    [SerializeField] private List<Wave> _waves;

    private Coroutine _coroutine;
    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private int _counter = 0;

    public int CurrentCountMinotaurs => _currentWave.Count;

    private void Start()
    {
        SetWave(_currentWaveIndex);
        Init(_currentWave.Count, _currentWave.Prefab, _currentWave.Delay);
    }

    private void OnDestroyEnemy()
    {
        _counter++;

        if (_counter == _currentWave.Count)
        {
            if (_currentWaveIndex < _waves.Count)
            {
                SetWave(_currentWaveIndex);
                Init(_currentWave.Count, _currentWave.Prefab, _currentWave.Delay);
            }
            _counter = 0;
        }
    }

    private void SetWave(int waveIndex)
    {
        _currentWave = _waves[waveIndex];
    }

    private void Init(int countMinotaurs, EnemyPresenter prefab, float delay)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(InitMinotaur(countMinotaurs, prefab, delay));
    }

    private IEnumerator InitMinotaur(int countMinotaurs, EnemyPresenter prefab, float delay)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);

        for (int i = 0; i < countMinotaurs; i++)
        {
            EnemyPresenter enemyController = Instantiate(prefab, transform.position, transform.rotation);
            enemyController.InitPlayerHealth(_playerHealthPresenter);
            enemyController.Destroing += OnDestroyEnemy;
            yield return waitForSeconds;
        }

        _currentWaveIndex++;
    }
}

[System.Serializable]
class Wave
{
    public EnemyPresenter Prefab;
    public float Delay;
    public int Count;
}