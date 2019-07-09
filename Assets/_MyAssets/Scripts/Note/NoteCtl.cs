using System;
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
        [SerializeField] private GameObject _effect;
        
        // ノート管理オブジェクト
        private NoteManager _noteManager;
        
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
            // 自身がその場に停止しているとき
            if (transform.parent == null)
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