using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailRoot : MonoBehaviour
{
    public RailPoint[] points;
    public List<Color> curveColor = new List<Color>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for(int i = 0; i < points.Length - 1; i++)
        {
            Gizmos.DrawLine(points[i].transform.position, points[i + 1].transform.position);
        }
        for(int i = 0; i < points.Length - 4; i++)
        {
            Gizmos.color = curveColor[i];
            for (float t = 0.0f; t < 1; t+=0.05f)
            {

                Vector3 position = GetPointOnBezierCurve(
                points[i].transform.position,
                points[i + 1].transform.position,
                points[i + 2].transform.position,
                points[i + 3].transform.position,
                t);                
                Gizmos.DrawSphere(position, 0.3f);
            }            
        }
    }

  
    private void Start()
    {
        points = GetComponentsInChildren<RailPoint>();
        for (int i = 0; i < points.Length - 4; i++)
        {
            curveColor.Add(new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)));
        }
    }

    Vector3 GetPointOnBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float u = 1f - t;
        float t2 = t * t;
        float u2 = u * u;
        float u3 = u2 * u;
        float t3 = t2 * t;

        Vector3 result =
            (u3) * p0 +
            (3f * u2 * t) * p1 +
            (3f * u * t2) * p2 +
            (t3) * p3;

        return result;
    }

}

