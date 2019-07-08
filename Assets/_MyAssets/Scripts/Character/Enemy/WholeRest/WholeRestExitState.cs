using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;

namespace _MyAssets.Scripts.Character.Enemy.WholeRest
{
    /// <summary>
    /// 全休符の退場ステート
    /// </summary>
    [Serializable]
    public class WholeRestExitState : IStateBase
    {
        private WholeRestCtl _ctl;
        private WholeRestStateMachine _stateMachine;

        public WholeRestExitState(WholeRestCtl ctl, WholeRestStateMachine stateMachine)
        {
            _ctl = ctl;
            _stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
            _ctl.StartApproach();
        }

        public void OnStateUpdate()
        {
        }

        public void OnStateFixedUpdate()
        {
        }

        public void OnStateExit()
        {
        }
    }
}