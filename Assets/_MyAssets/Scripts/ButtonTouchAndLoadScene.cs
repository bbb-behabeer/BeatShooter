using System;
using System.Threading.Tasks;
using _MyAssets.Scripts.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _MyAssets.Scripts
{
    /// <summary>
    /// 画面をタッチしてシーンをロードする
    /// </summary>
    public class ButtonTouchAndLoadScene: MonoBehaviour
    {
        // ロードするシーン
        [SerializeField] private string _scene;
        
        // 使用するフェードオブジェクト
        [SerializeField] private GameObject _FadeObject;

        // トランジションエフェクト
        private TransitionEffect _transitionEffect;

        private void Awake()
        {
            // ロード時にゲームオブジェクトを破壊されないように
            DontDestroyOnLoad(this.gameObject);
        }
        
        /// <summary>
        /// 次のシーンへフェード
        /// </summary>
        /// <returns></returns>
        public async Task FadeScene()
        {
            
            SceneManager.LoadScene(_scene);

            Destroy(gameObject);
        }

        public void FadeSceneOnClick()
        {
            FadeScene();
        }
    }
}