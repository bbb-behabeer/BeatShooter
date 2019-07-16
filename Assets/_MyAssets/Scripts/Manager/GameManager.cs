using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Manager
{
    public class GameManager: MonoBehaviour
    {
        // ゲームの時間
        [SerializeField] private float _duration;
        [SerializeField] private ScoreManager _scoreManager;

        // リザルトを表示している
        private bool _resultShowing = false;
        
        private void FixedUpdate()
        {
            // すでにリザルトを表示しているなら処理をしない
            if (_resultShowing) return;
                
            // リザルトを表示していないとき
            
            if (_duration < Time.timeSinceLevelLoad)
            {
                // duration経過後
                ShowResult();
            }
        }

        public void ShowResult()
        {
            // 一度だけスコアを表示
            _scoreManager.UpdateLeftNumList();
            _scoreManager.ShowScoreText();
            
            _resultShowing = true;
        }
    }
}