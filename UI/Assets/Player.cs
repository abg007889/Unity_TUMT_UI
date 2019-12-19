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
    public Text textTime;
    public float gameTime;

    private void Start()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);

        if (other.tag == "Trap")
        {
            int d = other.GetComponent<Trap>().damage;
            hp -= d;
            hpSlider.value = hp;
        }
        if (other.tag == "Chicken")
        {
            chickenCount++;
            textChicken.text = "CHICKEN : " + chickenCount + " / " + chickenTotal;
            Destroy(other.gameObject);
        }
        if (other.name == "Protal" && chickenCount == chickenTotal)
        {
            print("Game Win");
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
        }
    }
}
