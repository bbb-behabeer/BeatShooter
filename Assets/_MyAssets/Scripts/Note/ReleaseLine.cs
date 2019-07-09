using System;
using _MyAssets.Scripts.Character.Note;
using _MyAssets.Scripts.Common;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
   
    /// <summary>
    /// ノートを再生するライン
    /// プレイヤーが衝突するとノートを再生
    /// </summary>
    public class ReleaseLine: MonoBehaviour
    { 
        [SerializeField]
        private NoteManager _melody;
        [SerializeField]
        private NoteManager _uraMelody;
        [SerializeField]
        private NoteManager _bass;
        [SerializeField]
        private NoteManager _percussion;
        [SerializeField]
        private NoteManager _effect;
        [SerializeField]
        private NoteManager _fillin;
        [SerializeField]
        private GameObject _HitEffect;
        
        // エフェクトの位置
        [SerializeField] 
        private Transform _effectPosition;

        // リリースノートのキャッシュ
        private GameObject _releaseNoteCache;

        private SpriteRenderer _sprite;
        private Color _cacheColor;
        [SerializeField] Color _pressedColor;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            // 色をキャッシュする
            _cacheColor = _sprite.color;
        }

        private void Update()
        {
            // スプライトの色をデフォルトに
            _sprite.color = _cacheColor;

            if (PlayerInput.MouseButtonState.Equals(MouseButtonState.Press))
            {
                // マウス押下時
                
                // スプライトの色を変更する
                _sprite.color = _pressedColor;
                
                // リリースする
                Release();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("ReleaseNote"))
            {
                // プレイヤーとの衝突時
                _releaseNoteCache = other.gameObject;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("ReleaseNote"))
            {
                // リリースラインからリリースノートが離脱したとき
                Release();
            }
        }

        /// <summary>
        /// リリースする
        /// </summary>
        private void Release()
        {
            // リリースノートのキャッシュがないとき処理をしない
            if (_releaseNoteCache == null) return;
            
            // キャッシュがあるとき以下の処理を実行
            
            // エフェクトを生成
            ReleaseEffect();
                
            // ノートを再生
            if (_melody != null)
                _melody.PlayClip();
                
            if (_uraMelody != null)
                _uraMelody.PlayClip();
                
            if (_bass != null)
                _bass.PlayClip();
                
            if (_percussion != null)
                _percussion.PlayClip();

            if (_effect != null)
                _effect.PlayClip();
                
            if (_fillin != null)
                _fillin.PlayClip();
            
            // releaseNoteを削除する
            Destroy(_releaseNoteCache);
            
            // ノートを削除する
            DestroyAllNote();

            // キャッシュをnullに
            _releaseNoteCache = null;
        }

        /// <summary>
        /// ノートを削除する
        /// </summary>
        private void DestroyAllNote()
        {
            var objs = GameObject.FindGameObjectsWithTag("Note");
            foreach (var obj in objs)
            {
                var n = obj.GetComponent<NoteCtl>();
                if (n.CanDestroy())
                {
                    n.DestroyThis();
                }
            }
        }

        /// <summary>
        /// エフェクトを生成する
        /// </summary>
        private void ReleaseEffect()
        {
            if (_HitEffect != null)
            {
                var obj = Instantiate(_HitEffect);
                if (_effectPosition != null)
                    obj.transform.position = _effectPosition.position;
            }
        }

    }
}