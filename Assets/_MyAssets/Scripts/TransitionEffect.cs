using System;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _MyAssets.Scripts
{
    /// <summary>
    /// トランジションのエフェクト
    /// </summary>
    public class TransitionEffect: MonoBehaviour
    {
        [SerializeField] private float _start = 0;
        [SerializeField] private float _end = 1f;

        private SpriteMask _spriteMask;

        // 幅
        private float _offset = 0.1f;

        // 待機秒
        private int _spanMillis = 100;
        
        // 期間
        [SerializeField] private float _duration = 4f;

        // フェード中
        private bool _fading = false;

        public bool fading => _fading;

        private void Awake()
        {
            // ロード時にゲームオブジェクトを破壊されないように
            DontDestroyOnLoad(this.gameObject);
        }
        
        private void Start()
        {
            _spriteMask = GetComponent<SpriteMask>();
            FadeIn();
        }

        [Button("FadeIn")]
        public async Task FadeIn()
        {
            _fading = true;
            _spriteMask.alphaCutoff = _end;
            // 終了値までカットオフを遷移
            while (_spriteMask.alphaCutoff < _start - _offset  || _spriteMask.alphaCutoff > _start + _offset)
            {
                _spriteMask.alphaCutoff = Mathf.Lerp(_spriteMask.alphaCutoff, _start, Time.deltaTime * _duration);
                await Task.Delay(_spanMillis);
            }

            // カットオフを開始値に設定
            _spriteMask.alphaCutoff = _start;

            _fading = false;
        }

        [Button("FadeOut")]
        public async Task FadeOut()
        {
            _fading = true;
            
            _spriteMask.alphaCutoff = _start;
            // 終了値までカットオフを遷移
            while (_spriteMask.alphaCutoff < _end - _offset  || _spriteMask.alphaCutoff > _end + _offset)
            {
                _spriteMask.alphaCutoff = Mathf.Lerp(_spriteMask.alphaCutoff, _end, Time.deltaTime * _duration);
                await Task.Delay(_spanMillis);
            }
            
            // カットオフを終了値に設定
            _spriteMask.alphaCutoff = _end;

            _fading = false;
        }
    }
}