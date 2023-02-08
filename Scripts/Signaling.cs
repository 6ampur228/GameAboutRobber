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
        _signaling.volume = 0f;
        _signaling.Play();

        StartCoroutine(IncreaseOrDecreaseVolume(1));
    }

    public void DecreaseVolume()
    {
        StartCoroutine(IncreaseOrDecreaseVolume(-1));
    }

    private IEnumerator IncreaseOrDecreaseVolume(int value)
    {
        for (int i = 0; i < _countFrame; i++)
        {
            _signaling.volume += Time.deltaTime * value;

            yield return null;
        }
    }
}
