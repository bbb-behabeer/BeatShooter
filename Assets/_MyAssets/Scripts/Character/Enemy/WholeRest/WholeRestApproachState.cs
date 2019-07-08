using _MyAssets.Scripts.Common;

namespace _MyAssets.Scripts.Character.Enemy.WholeRest
{
    /// <summary>
    /// プレイヤーへ接近するステート
    /// </summary>
    public class WholeRestApproachState: IStateBase
    {
        private WholeRestCtl _ctl;
        
        public WholeRestApproachState(WholeRestCtl ctl)
        {
            _ctl = ctl;
        }
        
        public void OnStateEnter()
        {
            if (_ctl != null)
            {
                // プレイヤーへの接近を開始する
                _ctl.StartApproach();
            }
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