using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBeforeSpawn = 1f;
    [SerializeField] private Rigidbody _cannonball;

    private Coroutine _timer;

    public void StartTimer()
    {
        if (_timer == null)
            _timer = StartCoroutine(Timer());
    }

    private void Spawn()
    {
        Instantiate(_cannonball, transform.position, Quaternion.identity);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timeBeforeSpawn);

        Spawn();

        _timer = null;
    }
}
