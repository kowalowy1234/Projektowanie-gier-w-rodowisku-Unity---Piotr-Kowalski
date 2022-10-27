using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Zadanie1 : MonoBehaviour
{
  List<Vector3> positions = new List<Vector3>();
  public List<int> pozycje_x;
  public List<int> pozycje_z;
  public List<Material> materials = new List<Material>();
  int objectCounter = 0;
  public float delay = 3.0f;
  public int objectAmount;
  public GameObject block;
  private Renderer r;

  void Start()
  {
    r = GetComponent<Renderer>();

    int boundX = Mathf.CeilToInt(r.bounds.extents.x);
    int boundZ = Mathf.CeilToInt(r.bounds.extents.z);
    int boundNegativeX = Mathf.CeilToInt(r.bounds.center.x - r.bounds.extents.x);
    int boundNegativeZ = Mathf.CeilToInt(r.bounds.center.z - r.bounds.extents.z);

    pozycje_x = new List<int>(Enumerable.Range(boundNegativeX, boundX * 2).OrderBy(x => System.Guid.NewGuid()).Take(10));
    pozycje_z = new List<int>(Enumerable.Range(boundNegativeZ, boundZ * 2).OrderBy(x => System.Guid.NewGuid()).Take(10));

    for (int i = 0; i < objectAmount; i++)
    {
      this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
    }

    StartCoroutine(GenerujObiekt());
  }

  IEnumerator GenerujObiekt()
  {
    foreach (Vector3 pos in positions)
    {
      if (this.objectCounter != objectAmount)
      {
        GameObject clone = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
        clone.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Count() - 1)];
        yield return new WaitForSeconds(this.delay);
      }
    }
    StopCoroutine(GenerujObiekt());
  }
}
