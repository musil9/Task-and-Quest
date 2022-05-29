using UnityEditor;
using UnityEngine;

    public abstract class State 
    {
    public abstract void Enter(Student entity);

    public abstract void Execute(Student entity);
    public abstract void Exit(Student entity);
    }
