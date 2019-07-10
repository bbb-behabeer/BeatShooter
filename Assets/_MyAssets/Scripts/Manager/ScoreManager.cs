using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _MyAssets.Scripts.Manager
{
    /// <summary>
    /// スコアを管理
    /// </summary>
    public class ScoreManager: MonoBehaviour
    {
        // 区間ごとのオブジェクトの数　初期
        private static List<int> _FirstNumList = new List<int>();
        // 区間ごとのオブジェクトの数　最後
        private static List<int> _LeftNumList = new List<int>();
        
        // 区間のトランスフォーム
        [SerializeField] 
        private Transform[] _distinctList;
        
        // スコアのテキスト
        [SerializeField]
        private TextMeshProUGUI _scoreText;

        // スコアのオブジェクト
        [SerializeField] private GameObject _result;

        void Start()
        {
            _FirstNumList.Clear();
            _LeftNumList.Clear();
            // 初期オブジェクトの数を記憶
            // リストを確保
            foreach (var t in _distinctList)
            {
                _FirstNumList.Add( t.childCount );
                _LeftNumList.Add(0);
            }
            
            if (_result != null) _result.SetActive(false);
        }

        /// <summary>
        /// オブジェクトの残りの数のリストを更新
        /// </summary>
        [Button("UpdateLeftNumList")]
        public void UpdateLeftNumList()
        {
            // リストを更新
            for (var i=0; i < _distinctList.Length; i++)
            {
                var t = _distinctList[i];
                _LeftNumList[i] = ( t.childCount);
            }
        }

        /// <summary>
        /// スコアを表示する
        /// </summary>
        [Button("ShowScoreText")]
        public void ShowScoreText()
        {
            if (_result != null)
                _result.SetActive(true);
            
            var str = "";
            
            // テキストの加工
            for (var i=0; i < _distinctList.Length; i++)
            {
                var f = _FirstNumList[i];
                var l = f - _LeftNumList[i];
                str += i + " : " + l + " / " + f + "<br>";
            }

            _scoreText.text = str;
        }
        
    }
}