using UnityEngine;

public class EnemyRoaming : MonoBehaviour
{
  public Transform positionA;
  public Transform positionB;
  private Transform currentDestination;
  private Transform nextDestination;
  private GameObject player;

  public float patrolSpeed = 3f;
  public float chaseSpeed = 4f;
  private bool playerVisible = false;
  private bool playerOutOfRange = true;

  private void Start()
  {
    currentDestination = positionB;
    nextDestination = positionA;
    player = GameObject.FindGameObjectWithTag("Player");
  }

  private void Update()
  {
    CheckIfPlayerInRange();

    if (!playerOutOfRange && playerVisible)
    {
      Vector3 newPosition = new Vector3(player.transform.position.x, transform.position.y, 0f);
      transform.position = Vector3.MoveTowards(transform.position, newPosition, chaseSpeed * Time.deltaTime);
    }
    else if (transform.position == currentDestination.transform.position)
    {
      Transform temp = currentDestination;
      currentDestination = nextDestination;
      nextDestination = temp;
    }
    else
    {
      transform.position = Vector3.MoveTowards(transform.position, currentDestination.transform.position, patrolSpeed * Time.deltaTime);
    }
  }

  private void CheckIfPlayerInRange()
  {
    if (player.transform.position.x < positionA.transform.position.x || player.transform.position.x > positionB.transform.position.x)
    {
      playerOutOfRange = true;
    }
    else
    {
      playerOutOfRange = false;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      playerVisible = true;
      CheckIfPlayerInRange();
    }

    if (!playerOutOfRange && playerVisible)
    {
      if (Vector3.Distance(positionA.transform.position, other.transform.position) < Vector3.Distance(positionB.transform.position, other.transform.position))
      {
        currentDestination = positionA;
        nextDestination = positionB;
      }
      else
      {
        currentDestination = positionB;
        nextDestination = positionA;
      }
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      playerVisible = false;
    }
  }
}
