using System;
using UnityEngine;

namespace _MyAssets.Scripts.Character
{
    /**
     * 弾丸の制御
     */
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerBulletCtl : MonoBehaviour
    {
        // 弾丸の速度
        [SerializeField] private Vector3 velocity;

        private Rigidbody2D _rb;

        void Start()
        {
            // 速度を設定
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = velocity;
        }

        void OnBecameInvisible()
        {
            // 画面外で消去
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Note") || other.CompareTag("UpperFrame"))
            {
                // ノートに接触したとき
                // ゲームオブジェクトを削除
                Destroy(this.gameObject);
            }
        }

        public void SetVelocity(Vector3 v)
        {
            velocity = v;
            if (_rb = null)
                _rb.velocity = velocity;
        }
    }
}