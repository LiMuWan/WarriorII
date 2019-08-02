using UnityEngine;

namespace Const
{
    public class Path    
    {
        /// <summary>
        /// 预制路径
        /// </summary>
        private const string PREFAB_PATH = "Prefabs/";
        /// <summary>
        /// UI预制路径
        /// </summary>
        public const string UI_PATH = PREFAB_PATH + "UI/";
        /// <summary>
        /// GameUI预制路径
        /// </summary>
        public const string GAME_UI_PATH = PREFAB_PATH + "GameUI/";
        /// <summary>
        /// 音效路径
        /// </summary>
        public const string AUDIO_PATH = "Audio/";
        /// <summary>
        /// 玩家音效路径
        /// </summary>
        public const string AUDIO_PLAYER_PATH = AUDIO_PATH + "Player/";
        /// <summary>
        /// UI音效路径
        /// </summary>
        public const string UI_AUDIO_PATH = AUDIO_PATH + "UI/";
        /// <summary>
        /// BG音效路径
        /// </summary>
        public const string BG_AUDIO_PATH = AUDIO_PATH + "BG/";
        public const string COMICS_PREFAB_PATH = PREFAB_PATH + "Comics/";
        public const string COMICS_PATH = "Comics/";
        /// <summary>
        /// 漫画Item路径
        /// </summary>
        public const string COMICS_ITEM_PREFAB_PATH = COMICS_PREFAB_PATH + "ComicsItem";
        /// <summary>
        /// 人物HumanSkillItem UI预制路径
        /// </summary>
        public const string HUMAN_SKILL_ITEM_UI_PATH = GAME_UI_PATH + "HumanSkillItem";
    }
}
