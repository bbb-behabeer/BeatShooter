using System;
using _MyAssets.Scripts.Character;
using UnityEngine;

namespace _MyAssets.Scripts.Base
{
    /**
      * ステートマシーン基底
     */
    public class StateMachineBase: MonoBehaviour
    {
        // ステート
        protected IStateBase _state = null;
        protected IStateBase _cacheState = null;
        
        /**
         * ステートからアクセスして
         * 実行ステートを変更する
         */
        public void Transition(IStateBase state)
        {
            // ステート離脱処理
            _state.OnStateExit();
            _state = state;
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

        void OnWillRenderObject()
        {
        }


        // （必要であれば外部からもステート操作を可能に）
        // 次のステートへ移動する
        /*public void NextState()
        {
            // ステート離脱とみなしてOnStateExitを実行する
            _state.OnStateExit();
            _state = _state.Next;
        }*/
    }
}