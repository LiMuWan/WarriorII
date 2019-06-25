using UnityEngine;

namespace Game.Interface
{
    public interface IAni
    {
        void Play(int aniIndex);
    }

    public interface IPlayerAni:IAni,IPlayerBehaviour
    {

    }
}
