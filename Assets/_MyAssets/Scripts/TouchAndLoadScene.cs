using System;
using System.Threading.Tasks;
using _MyAssets.Scripts.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _MyAssets.Scripts
{
    /// <summary>
    /// 画面をタッチしてシーンをロードする
    /// </summary>
    public class TouchAndLoadScene: MonoBehaviour
    {
        // ロードするシーン
        [SerializeField] private string _scene;
        
        // 使用するフェードオブジェクト
        [SerializeField] private GameObject _FadeObject;

        // トランジションエフェクト
        private TransitionEffect _transitionEffect;

        
        private bool _loading = false;

        private void Awake()
        {
            // ロード時にゲームオブジェクトを破壊されないように
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            // フェードオブジェクトを生成して
            _FadeObject = Instantiate(_FadeObject);
            _transitionEffect = _FadeObject.GetComponent<TransitionEffect>();
        }

        private void Update()
        {
            if (PlayerInput.ButtonDown)
            {
                FadeScene();
            }
        }

        /// <summary>
        /// 次のシーンへフェード
        /// </summary>
        /// <returns></returns>
        private async Task FadeScene()
        {
            // ロード中のとき処理をしない
            if (_loading) return;
            
            _loading = true;
            
            if (_transitionEffect != null)
                await _transitionEffect.FadeOut();
            
            SceneManager.LoadSceneAsync(_scene);

            await _transitionEffect.FadeIn();
            
            Destroy(gameObject);
            Destroy(_FadeObject);
        }
    }
}