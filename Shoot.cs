using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition.x));
            Pool.Instance.Get("Bullet");
        }
    }
}