using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using _MyAssets.Scripts.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの管理
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class NoteManager: MonoBehaviour
    {
        private static NoteManager _instance = null;

        public static NoteManager Instance => _instance;
        
        // 入力の許容範囲
        [SerializeField] private float _range;
        public float Range => _range;

        // 一小節の長さ
        [SerializeField] private float _duration = 1f;
        public float Duration => _duration;
        
        [SerializeField] private int _beat = 4;
        public int Beat => _beat;

        [SerializeField] private int _bbeat = 8;
        public int BBeat => _bbeat;
        
        // 一拍の時間
        public float DurationPerBeat => _duration / (float)_beat;

        // ビート
        public float BBeatPerBeat => (float)_bbeat / (float)_beat;

        // モーメントの配列
        //[SerializeField] private List<int> _momentList;

        // オーディオソース
        private AudioSource _audioSource;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            
        }

        public void PlaySE(AudioClip clip)
        {
            //_audioSource.PlayOneShot(clip);
        }
    }
}