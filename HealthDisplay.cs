using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay: MonoBehaviour
{
   public int maxHealth = 3;

   public GameObject[] hearts;
   public int life;

   public void TakeDamage(int damage)
   {
      life -= damage;
      hearts[life].gameObject.SetActive(false);
   }

   public void AddHealth()
   {
      if (life != maxHealth)
      {
         life++;
         hearts[life-1].gameObject.SetActive(true);
         hearts[life - 1].gameObject.GetComponent<Animation>().Play("Heart Animation");
      }
   }

}
