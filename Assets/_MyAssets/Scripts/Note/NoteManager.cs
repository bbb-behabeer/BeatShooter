using System.Collections.Generic;
using _MyAssets.Scripts.Character.Note;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの管理
    /// </summary>
    public class NoteManager: MonoBehaviour
    {
        [SerializeField] private Part part;
        
        // 各パートのノート配列
        private List<AudioClip> _noteList;

        // 各パートの再生フラグ
        private bool _playable;

        // 各パートのオーディオソース
        private AudioSource _audioSource;
        
        // ボリュームUI
        [SerializeField] private Animator _volumeUI;
        
        // ボリューム
        [SerializeField] private float _volumeMax = 1f;
        [SerializeField] private float _volumeMin = 0.5f;
        
        // ノート配列のオフセット
        private int _offset;

        [Button("Start")]
        private void Start()
        {
            // オフセットを初期化する
            _offset = 0;
            
            // オーディオクリップを読み込む
            _noteList = new List<AudioClip>(Resources.LoadAll<AudioClip>("Sounds/" + part.ToString()));
            
            // オーディオソースを設定
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _audioSource.loop = false;
        }

        /// <summary>
        /// オーディオクリップを再生する
        /// </summary>
        [Button("PlayClip")]
        public void PlayClip()
        {
            // 曲が終了していたら処理をしない
            if (_offset >= _noteList.Count) return;
            
            if (_playable)
            {
                // 再生可能のとき
                // ノートを再生する
                //_audioSource.clip = _noteList[_offset];
                _audioSource.PlayOneShot(_noteList[_offset]);
                _volumeUI.Play("VolumePlaying");
                
                // ボリュームを最大に
                _audioSource.volume = _volumeMax;
                
                // オフセットを増やす
                _offset++;
            }

            // 再生不可能にリセット
            _playable = false;
        }

        /// <summary>
        /// 次のオーディオクリップをスキップする
        /// </summary>
        [Button("SkipClip")]
        public void SkipClip()
        {
            _offset++;
            _playable = false;

            _audioSource.volume = _volumeMin;
        }

        /// <summary>
        /// メロディが再生可能かを設定する
        /// </summary>
        /// <param name="playable">再生可能/不可能</param>
        public void SetPlayable(bool playable)
        {
            // 再生可能/不可能を設定
            _playable = playable;
        }
    }
}