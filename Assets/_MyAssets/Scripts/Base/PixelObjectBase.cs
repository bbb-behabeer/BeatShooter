using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * https://qiita.com/pixelflag/items/ad817bdd64931e084a46
 */
public class PixelObjectBase : MonoBehaviour
{
    private Vector3 cashPosition;

    void LateUpdate()
    {
        cashPosition = transform.position;
        transform.position = new Vector3(
            Mathf.RoundToInt(cashPosition.x),
            Mathf.RoundToInt(cashPosition.y),
            Mathf.RoundToInt(cashPosition.z)
        );
    }

    void OnRenderObject()
    {
        transform.position = cashPosition;
    }
}