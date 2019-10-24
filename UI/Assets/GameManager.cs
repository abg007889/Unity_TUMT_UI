using UnityEngine;
using UnityEngine.Audio; // using Audio API(功能)

public class GameManager : MonoBehaviour {
    public AudioMixer mixer;
    public void SetVBGM(float value)
    {
        mixer.SetFloat("VBGM", value);
    }
}
