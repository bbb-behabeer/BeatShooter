namespace _MyAssets.Scripts.Base
{
    /// <summary>
    /// 基底ステート
    /// </summary>
    public interface IStateBase
    {
        /// <summary>
        /// ステート開始時
        /// </summary>
        void OnStateEnter();
        
        /// <summary>
        /// ステート滞在時
        /// </summary>
        void OnStateUpdate();

        /// <summary>
        /// ステート滞在時
        /// </summary>
        void OnStateFixedUpdate();

        /// <summary>
        /// ステート脱出時
        /// </summary>
        void OnStateExit();
    }
}