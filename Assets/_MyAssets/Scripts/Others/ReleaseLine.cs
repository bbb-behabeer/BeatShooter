using System;
using System.Threading.Tasks;
using _MyAssets.Scripts.Character.Note;
using UnityEngine;

namespace _MyAssets.Scripts.Others
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

        private Animator _anim;

        [SerializeField]
        private GameObject _HitEffect;
        
        // エフェクトの位置
        [SerializeField] 
        private Transform _effectPosition;
        
        private void Start()
        {
            // アニメーターを取得
            _anim = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("ReleaseNote"))
            {
                // プレイヤーとの衝突時
                
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
                
                // releaseNoteを削除する
                Destroy(other.gameObject);
                
                // ノートを削除する
                DestroyAllNote();
            }
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
                    n.Destroy();
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