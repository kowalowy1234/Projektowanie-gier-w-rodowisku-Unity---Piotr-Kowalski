using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie5 : MonoBehaviour
{

  public GameObject cube;
  public List<Vector3> positions;
  private Vector3 newPosition;

  void Start()
  {
    int x;
    int z;

    for (int i = 1; i <= 10; i++)
    {
      x = Random.Range(-10, 11);
      z = Random.Range(-10, 11);
      newPosition = new Vector3(x, transform.position.y, z);
      while (positions.Contains(new Vector3(x, transform.position.y, z)))
      {
        x = Random.Range(1, 11);
        z = Random.Range(1, 11);
        newPosition = new Vector3(x, transform.position.y, z);
      }
      positions.Add(newPosition);
      Instantiate(cube, newPosition, Quaternion.identity);
    }
  }
}
