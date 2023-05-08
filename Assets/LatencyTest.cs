using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatencyTest : MonoBehaviour
{
    public Camera cam;
    public AudioSource audioSource;

    private float _bufferLatency = 0;
    private int _prevEights = -1;
    private Color _color = Color.white;

    public float EstimateLatency()
    {
        var cfg = AudioSettings.GetConfiguration();
        var unityInternalBufferLatency =  cfg.dspBufferSize / (float)(cfg.sampleRate);

        // this was obtained by filming the screen with wired headphones very close to camera
        var measuredLatency = 0.0833333f;         
        var unityInternalBufferLatencyOnMeasuaredSystem = 0.02133333f;

        return measuredLatency - unityInternalBufferLatencyOnMeasuaredSystem + unityInternalBufferLatency;
    }
    
    void OnEnable()
    {
        audioSource.Play();
        _bufferLatency = EstimateLatency();
        Debug.Log("buffer latency: " + _bufferLatency);
    }

    void Update()
    {
        var t = audioSource.time - _bufferLatency;
        var eights = Mathf.FloorToInt(t*4f);
        var colorIntensity = 0.1f;

        if(eights >= 0 && eights != _prevEights && eights <= 16 && eights%8 != 7)
        {
            //Debug.Log("eights: " + eights);
            colorIntensity = 1f;
            if(eights%8 == 0)
            {
                if(eights%16 == 0)
                    _color = Color.green; 
                else
                    _color = Color.red; 
            }
            else
                _color = Color.blue; 
        }

        cam.backgroundColor = _color * colorIntensity;
        _prevEights = eights;
    }
}
