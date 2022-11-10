using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie4Lab6 : MonoBehaviour
{

  // Movement script of player object
  private Zadanie2Lab4 player;

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      player = other.GetComponent<Zadanie2Lab4>();
      player.velocity.y = Mathf.Sqrt(player.jumpHeight * -3.0f * player.gravity) * 3;
    }
  }
}
