using System;
using UnityEngine;

namespace _MyAssets.Scripts.Common
{
    /// <summary>
    /// 所定のタグオブジェクトとあたったとき
    /// 音声を再生
    /// </summary>
    public class HitSound: MonoBehaviour
    {
        // オーディオソース
        private AudioSource _audioSource;
        // ヒットするタグ
        [SerializeField] private String _tag;
        
        // 音声
        [SerializeField]private AudioClip _clip;
        
        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.loop = false;
            _audioSource.playOnAwake = false;
            _audioSource.clip = _clip;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(_tag))
            {
                // タグとあたったとき
                // 音声を再生
                _audioSource.Play();
                //_audioSource.PlayOneShot(_clip);
            }
        }
    }
}