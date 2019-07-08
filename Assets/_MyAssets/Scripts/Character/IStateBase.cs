using System.Xml.Serialization;

namespace _MyAssets.Scripts.Character
{
    /**
     * キャラクターのステート（基底）
     */
    public interface IStateBase
    {
        /**
         * ステート開始時に実行
         */
        void OnStateEnter();
        
        /**
         * （スタートと同じタイミングから）
         * ステート滞在時に実行
         */
        void OnStateUpdate();

        /**
         * ステート滞在、
         * transform変更時に使用
         */
        void OnStateFixedUpdate();

        /**
         * ステート離脱時に実行
         */
        void OnStateExit();
    }
}