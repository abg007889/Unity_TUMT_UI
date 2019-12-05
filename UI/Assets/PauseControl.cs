using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour {

    [Header("StopPage")]
    public Image imagePause;
    public Sprite spritePause, spritePlay;
    [Header("Stop")]
    public bool pause;

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Stop~");
            pause = !pause;
            imagePause.sprite = pause ? spritePlay : spritePause;
            Time.timeScale = pause ? 0 : 1;
        }
    }

    private void Update()
    {
        Pause();
    }

}
