using System;
using UnityEngine;

namespace _MyAssets.Scripts.Common
{
    /// <summary>
    /// オブジェクトをスクロールする
    /// </summary>
    public class Scroll: MonoBehaviour
    {
        // スクロールする速度
        [SerializeField]
        private Vector2 _velocity;

        // 位置Zのキャッシュ
        private float _cacheZ;
        
        void Start()
        {
            _cacheZ = transform.position.z;
        }

        private void FixedUpdate()
        {
            var nx = transform.position.x + _velocity.x * Time.deltaTime;
            var ny = transform.position.y + _velocity.y * Time.deltaTime;
            transform.position = new Vector3(nx, ny, _cacheZ);
        }
    }
}