using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> transitions;
    [SerializeField] protected Animator Animator;

    public void Enter()
    {
        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
