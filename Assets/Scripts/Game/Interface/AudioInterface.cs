using UnityEngine;

namespace Game.Interface
{
    public interface AudioInterface
    {
        void Play(string name,float volume);   
    }

    public interface IPlayerAudio:AudioInterface,IPlayerBehaviour
    {

    }
}
