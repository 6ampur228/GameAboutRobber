using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signaling;
    [SerializeField] private float _speedDeceleration;

    private int _countFrame = 700;

    public void IncreaseVolume()
    {
        int positiveValue = 1;

        _signaling.volume = 0f;
        _signaling.Play();

        StartCoroutine(IncreaseOrDecreaseVolume(positiveValue));
    }

    public void DecreaseVolume()
    {
        int negativeValue = -1;

        StartCoroutine(IncreaseOrDecreaseVolume(negativeValue));
    }

    private IEnumerator IncreaseOrDecreaseVolume(int value)
    {
        int minVolume = 0;
        int maxVolume = 100;

        for (int i = 0; i < _countFrame; i++)
        {
            _signaling.volume += Time.deltaTime * value;

            if (_signaling.volume == minVolume || _signaling.volume == maxVolume)
                yield break;

            yield return null;
        }
    }
}
