using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _MyAssets.Scripts.Common
{
    
    /**
     * カメラを操作する
     * ソース元
     * https://qiita.com/pixelflag/items/ad817bdd64931e084a46
     */
    /// <summary>
    /// カメラを制御する
    /// </summary>
    public class CameraCtl : PixelObjectBase
    {

        [SerializeField]
        private GameObject targetObject;

        [SerializeField]
        private Collider2D fieldCollider;

        void Start ()
        {
        }

        void Update ()
        {
            Vector3 pos = targetObject.transform.position;

            float left   = fieldCollider.bounds.min.x + Screen.width  / 2;
            float bottom = fieldCollider.bounds.min.y + Screen.height / 2;
            float right  = fieldCollider.bounds.max.x - Screen.width  / 2;
            float top    = fieldCollider.bounds.max.y - Screen.height / 2;

            if (pos.x < left)
            {
                pos.x = left;
            }
            else if(pos.x > right)
            {
                pos.x = right;
            }

            if (pos.y > top)
            {
                pos.y = top;
            }
            else if (pos.y < bottom)
            {
                pos.y = bottom;
            }

            pos.z = transform.position.z;
            transform.position = pos;
        }
    }
}