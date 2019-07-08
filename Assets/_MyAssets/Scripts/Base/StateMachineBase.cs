using UnityEngine;

namespace _MyAssets.Scripts.Base
{
    /// <summary>
    /// 基底ステートマシン
    /// </summary>
    public class StateMachineBase: MonoBehaviour
    {
        // ステート
        protected IStateBase _state = null;
        private IStateBase _cacheState = null;

        /// <summary>
        /// 実行ステートを遷移する
        /// </summary>
        /// <param name="state">遷移先ステート</param>
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
    }
}