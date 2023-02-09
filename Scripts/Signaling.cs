using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signaling;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    //private IEnumerator coroutineIncreaseVolume;
    //private IEnumerator coroutineDecreaseVolume;

    /*public void Start()
    {
        coroutineIncreaseVolume = IncreaseOrDecreaseVolume(_maxVolume);
        coroutineDecreaseVolume = IncreaseOrDecreaseVolume(_minVolume);
    }*/

    public void IncreaseVolume()
    {
        //StopCoroutine(coroutineDecreaseVolume);
        //StartCoroutine(coroutineIncreaseVolume);
        StopAllCoroutines();
        StartCoroutine(IncreaseOrDecreaseVolume(_maxVolume));
    }

    public void DecreaseVolume()
    {
        //StopCoroutine(coroutineIncreaseVolume);
        //StartCoroutine(coroutineDecreaseVolume);
        StopAllCoroutines();
        StartCoroutine(IncreaseOrDecreaseVolume(_minVolume));
    }

    public void Play()
    {
        _signaling.volume = _minVolume;
        _signaling.Play();
    }

    private IEnumerator IncreaseOrDecreaseVolume(float volume)
    {
        while (_signaling.volume != volume)
        {
            _signaling.volume = Mathf.MoveTowards(_signaling.volume, volume, Time.deltaTime);

            yield return null;
        }
    }
}
