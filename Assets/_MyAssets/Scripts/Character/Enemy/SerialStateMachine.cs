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
        private IStateBase _state = null;
        private IStateBase _cacheState = null;
        
        // ステート配列
        [SerializeField] private List<IStateBase> _stateList = new List<IStateBase>();

        // ステート配列のオフセット
        private int _offset = -1;
        
        /// <summary>
        /// 実行ステートを遷移する
        /// </summary>
        public void Next()
        {
            // ステート離脱処理
            _state.OnStateExit();
            
            _offset++;

            if (_offset < _stateList.Count)
            {
                // 次のステートがあるとき
                // そのまま遷移
                _state = _stateList[_offset];
            }
            else
            {
                // 次のステートがないとき
                // ステートをNULLに
                _state = null;
            }
        }
        
        void Update()
        {
            // ステートが設定されていないとき退避
            if (_state == null) return;

            // 以前のステートと違うとき、
            // ステート開始とみなしてOnStateEnterを実行する
            if (_state != _cacheState)
                _state.OnStateEnter();
            
            // ステート滞在処理
            _state.OnStateUpdate();
        }

        void FixedUpdate()
        {
            _state.OnStateFixedUpdate();
        }
        
    }
}