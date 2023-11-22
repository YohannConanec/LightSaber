using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private float _steps;
    [SerializeField] private AudioSource _beepAudio;
    private float _duration;
    private float _nextbeatTime;


    private void Start()
    {
        _beepAudio = _beepAudio.GetComponent<AudioSource>();
        _duration = BeatDuration();
        _nextbeatTime = Time.time + _duration;

        //StartCoroutine(beepRoutine(_duration, _beepAudio));
    }

    private void Update()
    {
        if(Time.time >= _nextbeatTime)
        {
            _beepAudio.Play();
            _nextbeatTime += _duration;
        }
    }

    private float BeatDuration()
    {
        return (60f / _bpm * _steps);
    }

    /*
    IEnumerator beepRoutine(float duration, AudioSource audio)
    {
        while (true)
        {
            yield return new WaitForSeconds(duration);
            audio.Play();
        }
         
    }*/

}
