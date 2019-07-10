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
        [SerializeField] private bool _visible = false;

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
                    _noteManager.SetPlayable();
                // 自身をその場に停止 
                transform.parent = null;
            }
        }

        private void OnWillRenderObject()
        {
            if (Camera.current.name != "SceneCamera" && Camera.current.name != "Preview Camera")
            {
                // すでに可視なら処理を無視
                if (_visible) return;
                
                // カメラ内に表示されたとき（ゲームビューのみ）
                if (_noteManager != null)
                {
                    // スキップ可能に設定
                    // 可視に設定
                    _noteManager.SetSkippable();
                    _visible = true;
                }
            }
        }

        /// <summary>
        /// 削除できるか
        /// </summary>
        /// <returns></returns>
        public bool CanDestroy()
        {
            // 可視のとき
            if (_visible)
                return true;
            return false;
        }

        /// <summary>
        /// 削除する
        /// </summary>
        public void DestroyThis()
        {
            // エフェクトを生成
            var effect = Instantiate(_effect);
            effect.transform.position = transform.position;
            
            // 自身を削除
            Destroy(this.gameObject);
        }
    }
}