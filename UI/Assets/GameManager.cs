using UnityEngine;
using UnityEngine.Audio; // using Audio API(功能)
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    public AudioMixer mixer;
    public Text loadingText;
    public Slider loading;
    public void SetVBGM(float value)
    {
        mixer.SetFloat("VBGM", value);
    }
    public void SetVSFX(float value)
    {
        mixer.SetFloat("VSFX", value);
    }
    public void Play()
    {
        //SceneManager.LoadScene("Game_Demo");
        StartCoroutine(Loading());
    }

    //協同程序 Coroutine
    private IEnumerator Loading()
    {
        //print("test 1");
        //yield return new WaitForSeconds(1);
        //print("test 2");

        AsyncOperation ao = SceneManager.LoadSceneAsync("Game_Demo");
        ao.allowSceneActivation = false;

        while(ao.isDone == false)
        {
            loadingText.text = ((ao.progress / 0.9f) * 100).ToString();
            loading.value = ao.progress / 0.9f;
            yield return new WaitForSeconds(0.0001f);

            if(ao.progress == 0.9f && Input.anyKey)
            {
                ao.allowSceneActivation = true;
            }
        }

    }
}
