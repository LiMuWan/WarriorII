//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int GameCameraState = 0;
    public const int GameGameState = 1;
    public const int GameModelHumanSkillConfig = 2;
    public const int GamePlayerAniState = 3;
    public const int GamePlayer = 4;
    public const int GameValidHumanSkill = 5;
    public const int GameCameraStateListener = 6;
    public const int GameValidHumanSkillListener = 7;

    public const int TotalComponents = 8;

    public static readonly string[] componentNames = {
        "GameCameraState",
        "GameGameState",
        "GameModelHumanSkillConfig",
        "GamePlayerAniState",
        "GamePlayer",
        "GameValidHumanSkill",
        "GameCameraStateListener",
        "GameValidHumanSkillListener"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Game.CameraState),
        typeof(Game.GameStateComponent),
        typeof(Game.Model.HumanSkillConfigComponent),
        typeof(Game.PlayerAniState),
        typeof(Game.PlayerComponent),
        typeof(Game.ValidHumanSkillComponent),
        typeof(GameCameraStateListenerComponent),
        typeof(GameValidHumanSkillListenerComponent)
    };
}
