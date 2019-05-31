using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    [Game,Unique]
    public class FindObjectServiceComponent:IComponent
    {
        public IFindObjectService FindObjectService;
    }
}
