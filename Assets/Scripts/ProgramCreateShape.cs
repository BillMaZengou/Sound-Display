using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramCreateShape : MonoBehaviour
{
    public GameObject pointPrefab;

    [Range(10, 100)]
    public int groupNum = 100;
    public LineRenderer line2;
    private LineRenderer line;

    Transform[] points;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();

        float step = 10f / groupNum;
        Vector3 scale = Vector3.one * step;

        points = new Transform[groupNum];

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab).transform;
            point.localScale = scale;
            point.SetParent(this.transform, false);
            points[i] = point;
        }
    }

    private void Start()
    {
        int group = 1;

        float t = Time.time;

        float step = 2f / groupNum;

        for (int x = 0; x < groupNum; x++)
        {
            float u = (x + 0.5f) * step - 1f;
            points[x].localPosition = Cylinder(u);
            points[x].GetComponent<VisableGroup>().groupIndex = group;
            group++;
        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < groupNum; i++)
        {
            line.SetPosition(i, points[i].GetComponent<VisableGroup>().link1.position);
        }
        line.SetPosition(groupNum, points[0].GetComponent<VisableGroup>().link1.position);

        for (int i = 0; i < groupNum; i++)
        {
            line2.SetPosition(i, points[i].GetComponent<VisableGroup>().link2.position);
        }
        line2.SetPosition(groupNum, points[0].GetComponent<VisableGroup>().link2.position);
    }

    const float pi = Mathf.PI;

    static Vector3 Cylinder(float u)
    {
        Vector3 p;
        p.x = Mathf.Sin(pi * u);
        p.y = Mathf.Cos(pi * u);
        p.z = 0;
        return p;
    }
}
