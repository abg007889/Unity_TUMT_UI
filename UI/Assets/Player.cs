using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int hp = 100;
    public Slider hpSlider;

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);

        if(other.tag == "Trap")
        {
            int d = other.GetComponent<Trap>().damage;
            hp -= d;
            hpSlider.value = hp;
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
