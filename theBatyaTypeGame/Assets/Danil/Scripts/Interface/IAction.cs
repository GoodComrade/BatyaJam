using System;

namespace Danil.Scripts.Interface
{
    public interface IAction
    {
        event Action OnAction;
    }
    
    public interface IAction<T>
    {
        event Action<T> OnAction;
    }
}