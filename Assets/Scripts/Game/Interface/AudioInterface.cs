using UnityEngine;

namespace Game.Interface
{
    public interface AudioInterface
    {
        void Play(string name);   
    }

    public interface IPlayerAudio:AudioInterface,IPlayerBehaviour
    {

    }
}
