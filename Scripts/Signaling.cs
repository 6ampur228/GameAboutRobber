using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signaling;

    private Coroutine _currentCoroutine;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    public void IncreaseVolume()
    {
        if(_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void DecreaseVolume()
    {
        StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    public void Play()
    {
        _signaling.volume = _minVolume;
        _signaling.Play();
    }

    private IEnumerator ChangeVolume (float volume)
    {
        while (_signaling.volume != volume)
        {
            _signaling.volume = Mathf.MoveTowards(_signaling.volume, volume, Time.deltaTime);

            yield return null;
        }
    }
}
