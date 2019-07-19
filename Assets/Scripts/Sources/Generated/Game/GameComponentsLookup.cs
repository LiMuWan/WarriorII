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
    public const int GamePlayerAniState = 2;
    public const int GamePlayer = 3;
    public const int GameValidHumanSkill = 4;
    public const int GameCameraStateListener = 5;
    public const int GameValidHumanSkillListener = 6;

    public const int TotalComponents = 7;

    public static readonly string[] componentNames = {
        "GameCameraState",
        "GameGameState",
        "GamePlayerAniState",
        "GamePlayer",
        "GameValidHumanSkill",
        "GameCameraStateListener",
        "GameValidHumanSkillListener"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Game.CameraState),
        typeof(Game.GameStateComponent),
        typeof(Game.PlayerAniState),
        typeof(Game.PlayerComponent),
        typeof(Game.ValidHumanSkillComponent),
        typeof(GameCameraStateListenerComponent),
        typeof(GameValidHumanSkillListenerComponent)
    };
}
