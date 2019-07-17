using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    [RequireComponent(typeof(LineRenderer))]
    
    public class AimLine: MonoBehaviour
    {
        private LineRenderer _lineRenderer;

        private void Start()
        {
            _lineRenderer = gameObject.GetComponent<LineRenderer>();
        }

        private void FixedUpdate()
        {
            var mask = LayerMask.GetMask("Note");
            var hit = Physics2D.Raycast(transform.position, Vector2.up, mask);
            if (hit.collider != null)
            {
                // 線を引く
                var from = transform.position;
                var to = hit.point;
                
                var vs = new Vector3[2];
                vs[0] = from;
                vs[1] = to;
                
                _lineRenderer.SetPositions(vs);
            }
        }
    }
}