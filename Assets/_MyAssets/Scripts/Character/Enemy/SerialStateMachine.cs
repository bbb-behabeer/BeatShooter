using System.Collections.Generic;
using _MyAssets.Scripts.Base;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Enemy
{
    /// <summary>
    /// 全休符のステートマシン
    /// </summary>
    public class SerialStateMachine: MonoBehaviour
    {
        // ステート
        private StateBase _state = null;
        private StateBase _cacheState = null;
        
        // ステート配列
        [SerializeField] private List<StateBase> _stateList;

        // ステート配列のオフセット
        private int _offset = -1;
        
        /// <summary>
        /// 実行ステートを遷移する
        /// </summary>
        public void Next()
        {
            // ステート離脱処理
            if (_state != null)
            {
                _state.OnStateExit();
            }

            _offset++;

            if (_offset < _stateList.Count)
            {
                // 次のステートがあるとき
                // そのまま遷移
                _state = _stateList[_offset];
                _state.OnStateEnter();
            }
            else
            {
                // 次のステートがないとき
                // ステートをNULLに
                _state = null;
            }
        }

        void Start()
        {
            Next();
        }

        void Update()
        {
            // ステートが設定されていないとき退避
            if (_state == null) return;
            
            // ステート滞在処理
            _state.OnStateUpdate();
        }

        void FixedUpdate()
        {
            if (_state != null)
            {
                _state.OnStateFixedUpdate();
            }
        }
        
    }
}