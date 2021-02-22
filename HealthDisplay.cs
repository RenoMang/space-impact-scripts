using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int maxHealth = 3;

    public GameObject[] hearts;
    public int life;
    private int curlife;

    private void Start()
    {
        curlife = life;
    }

    public void TakeDamage(int damage)
    {
        curlife -= damage;
        if (curlife < 0)
        {
            curlife = 0;
        }
        hearts[curlife].gameObject.SetActive(false);
    }

    public void AddHealth()
    {
        if (life != maxHealth)
        {
            curlife++;
            hearts[curlife - 1].gameObject.SetActive(true);
            hearts[curlife - 1].gameObject.GetComponent<Animation>().Play("Heart Animation");
        }
    }

    public void ResetHealth()
    {
        for (int i = 0; i < life; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
        curlife = life;
    }
}
