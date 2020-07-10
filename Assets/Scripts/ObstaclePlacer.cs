using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    public List<GameObject> Obstacles = new List<GameObject>();
    public float XSize;
    public float ZSize;

    public float MinDistance;
    public int MaxFails;
    private int FailAmount = 0;
    public Vector3 Offset;

    private List<Vector3> Positions = new List<Vector3>();
    
    // Start is called before the first frame update
    void Start()
    {
        while (true)
        {
            Vector3 Position = new Vector3(Random.Range(0, XSize), 0, Random.Range(0, ZSize)) + Offset;

            RaycastHit hit;
            if (Physics.Raycast(Position, Vector3.down, out hit, Mathf.Infinity))
            {
                Position = hit.point;
                bool CanPlace = true;

                foreach (Vector3 TestPosition in Positions)
                {
                    if ((TestPosition - Position).sqrMagnitude < MinDistance * MinDistance)
                    {
                        CanPlace = false;
                        break;
                    }
                    
                }
                if (CanPlace)
                {
                    Positions.Add(Position);
                }
                else
                {
                    FailAmount++;
                }
            }

            if (FailAmount > MaxFails)
            {
                break;
            }
        }

        foreach (Vector3 Position in Positions)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Count)]).transform.position = Position + Vector3.up * 0.91f;
        }
        
    }
}
