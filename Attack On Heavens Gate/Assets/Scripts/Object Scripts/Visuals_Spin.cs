using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visuals_Spin : MonoBehaviour
{
    public Vector3 spinDirection;

    public float speed;

    private void Update()
    {
        SpinObject();
    }

    public void SpinObject()
    {
        transform.Rotate(spinDirection);
    }
}
