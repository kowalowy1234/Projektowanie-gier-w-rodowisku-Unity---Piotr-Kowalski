using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3Lab6 : MonoBehaviour
{
  public List<Vector3> positions = new List<Vector3>();
  private int direction = 1;
  private int nextPositionIndex = 0;

  public float speed;
  private bool isMoving;

  void Start()
  {
    positions.Insert(0, transform.position);
  }

  void FixedUpdate()
  {
    if (isMoving == true && transform.position == positions[nextPositionIndex])
    {
      if (nextPositionIndex + 1 == positions.Count)
      {
        isMoving = false;
        direction = -1;
      }

      if (nextPositionIndex == 0)
      {
        isMoving = false;
        direction = 1;
      }
      nextPositionIndex += direction;
    }

    if (isMoving == true)
    {
      transform.position = Vector3.MoveTowards(transform.position, positions[nextPositionIndex], speed * Time.deltaTime);
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      other.transform.parent = transform;
      isMoving = true;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    other.transform.parent = null;
  }
}
