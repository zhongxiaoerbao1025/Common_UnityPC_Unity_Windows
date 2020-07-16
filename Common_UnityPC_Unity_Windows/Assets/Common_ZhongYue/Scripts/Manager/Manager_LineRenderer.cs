using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_LineRenderer : MonoBehaviour
{
    protected LineRenderer lineRenderer;
    protected int pointAmount = 60;

    /// <summary>
    /// ����
    /// </summary>
    protected virtual void DrawLineRenderer()
    {
        if (lineRenderer != null)
        {

        }
    }
}

public class Bezier
{
    public List<Vector3> vertexs;

    //vertexCount:ֵԽ����Խ�⻬
    public Bezier(Vector3 p0, Vector3 p1, Vector3 p2, float vertexCount)
    {
        vertexs = new List<Vector3>();

        float interval = 1 / vertexCount;
        for (int i = 0; i < vertexCount; i++)
        {
            vertexs.Add(GetPoint(p0, p1, p2, i * interval));
        }
    }

    //vertexCount:ֵԽ����Խ�⻬
    public Bezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float vertexCount = 60)
    {
        vertexs = new List<Vector3>();

        float interval = 1 / vertexCount;
        for (int i = 0; i < vertexCount; i++)
        {
            vertexs.Add(GetPoint(p0, p1, p2, p3, i * interval));
        }
    }

    //t��[0,1]��Χ
    private Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        float a = 1 - t;
        Vector3 target = p0 * Mathf.Pow(a, 2) + 2 * p1 * t * a + p2 * Mathf.Pow(t, 2);
        return target;
    }

    //t��[0,1]��Χ
    private Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float a = 1 - t;
        Vector3 target = p0 * Mathf.Pow(a, 3) + 3 * p1 * t * Mathf.Pow(a, 2) + 3 * p2 * Mathf.Pow(t, 2) * a + p3 * Mathf.Pow(t, 3);
        return target;
    }
}
