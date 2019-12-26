using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("HP UI")]
    public int hp = 100;
    public Slider hpSlider;
    [Header("Chicken Area")]
    public Text textChicken;
    public int chickenCount;
    public int chickenTotal;
    [Header("Time Area")]
    public Text textTime;
    public float gameTime;
    [Header("End Canvas")]
    public GameObject final;
    public Text textBest;
    public Text textCurrent;

    private void Start()
    {
        if (PlayerPrefs.GetFloat("Best Score") == 0)
        {
            PlayerPrefs.SetFloat("Best Score", 99999);
        }
        chickenTotal = GameObject.FindGameObjectsWithTag("Chicken").Length;
        textChicken.text = "CHICKEN : 0 / " + chickenTotal;
    }

    private void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        gameTime += Time.deltaTime;
        textTime.text = "Time : " + gameTime.ToString("F2");
    }

    private void Dead()
    {
        final.SetActive(true);
        textCurrent.text = "Time : " + gameTime.ToString("F2");
        textBest.text = "Best : " + PlayerPrefs.GetFloat("Best Score").ToString("F2");
        Cursor.lockState = CursorLockMode.None;

        GetComponent<FPSControllerLPFP.FpsControllerLPFP>().enabled = false;
        enabled = false;
    }

    private void GameOver()
    {
        final.SetActive(true);
        textCurrent.text = "Time : " + gameTime.ToString("F2");

        if (gameTime < PlayerPrefs.GetFloat("Best Score"))
        {
            PlayerPrefs.SetFloat("Best Score", gameTime);
        }

        textBest.text = "Best : " + PlayerPrefs.GetFloat("Best Score").ToString("F2");

        Cursor.lockState = CursorLockMode.None;
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);

        if (other.tag == "Trap")
        {
            int d = other.GetComponent<Trap>().damage;
            hp -= d;
            hpSlider.value = hp;
            if (hp <= 0) Dead();
        }
        if (other.tag == "Chicken")
        {
            chickenCount++;
            textChicken.text = "CHICKEN : " + chickenCount + " / " + chickenTotal;
            Destroy(other.gameObject);
        }
        if (other.name == "Protal" && chickenCount == chickenTotal)
        {
            GameOver();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        print(other.gameObject);

        if (other.tag == "Trap")
        {
            int d = other.GetComponent<Trap>().damage;
            hp -= d;
            hpSlider.value = hp;
            if (hp <= 0) Dead();
        }
    }
}
