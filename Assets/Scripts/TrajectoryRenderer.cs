using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Vector3[] _points;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        _points = new Vector3[5];
        _lineRenderer.positionCount = _points.Length;

        for(int i = 0; i < _points.Length; i++)
        {
            float time = i * 0.1f;

            _points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
        }

        _lineRenderer.SetPositions(_points);
    }

    public void ClearPoints()
    {
        _lineRenderer.positionCount = 0;
    }
}
