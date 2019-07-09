using System;
using _MyAssets.Scripts.Note;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Note
{
    // パート情報
    public enum Part
    {
        Melody,
        UraMelody,
        Percussion,
        Bass,
        FillIn,
        Effect
    }
    
    /// <summary>
    /// ノートの制御
    /// </summary>
    public class NoteCtl: MonoBehaviour
    {
        // 担当するパート
        [SerializeField] private Part _part;
        // ノート再生時のエフェクト
        [SerializeField] private GameObject _effect;
        
        // ノート管理オブジェクト
        private NoteManager _noteManager;

        // 削除可能となるY座標
        [SerializeField] private float _destroyable = 200;
        
        void Start()
        {
            // NoteManagerをシーンから取得
            _noteManager = GameObject.Find(_part.ToString() + "Part").GetComponent<NoteManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerBullet"))
            {
                // パートを再生可能に
                if (_noteManager != null)
                    _noteManager.SetPlayable(true);
                // 自身をその場に停止 
                transform.parent = null;
            } else if (other.CompareTag("LowerBound"))
            {
                // カメラ範囲を超えたとき
                // ノートをスキップ
                if (_noteManager != null)
                    _noteManager.SkipClip();
                Destroy(gameObject);
            }
        }
        
        /// <summary>
        /// 削除できるか
        /// </summary>
        /// <returns></returns>
        public bool CanDestroy()
        {
            // 削除可能となる座標を超えたとき
            if (transform.position.y < _destroyable)
                return true;
            return false;
        }

        /// <summary>
        /// 削除する
        /// </summary>
        public void DestroyThis()
        {
            var effect = Instantiate(_effect);
            effect.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}