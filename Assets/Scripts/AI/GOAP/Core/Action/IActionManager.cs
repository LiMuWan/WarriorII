using UnityEngine;
using System;

namespace GOAP
{
    public interface IActionManager <TAction>
    {
        void AddHandler(TAction label);
        void RemoveHandler(TAction label);
        IActionHandler<TAction> GetHandler(TAction label);
        void UpdateData();
        void FrameFun();
        void ChangeCurrentAction(TAction label);
        void AddActionCompleteListener(Action complete);
    }
}
