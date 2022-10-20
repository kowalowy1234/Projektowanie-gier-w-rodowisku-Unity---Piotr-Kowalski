using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{

  public float speed;
  public Vector3[] cords;

  private int cordIndex = 0;

  void Update()
  {
    float distance = Vector3.Distance(transform.position, cords[cordIndex]);

    if (distance == 0f)
    {
      NextPosition();
    }

    transform.position = Vector3.MoveTowards(transform.position, cords[cordIndex], speed * Time.deltaTime);
  }

  void NextPosition()
  {
    if (cordIndex + 1 == cords.Length)
    {
      cordIndex = 0;
    }
    else
    {
      cordIndex += 1;
    }
    transform.LookAt(cords[cordIndex]);
  }
}