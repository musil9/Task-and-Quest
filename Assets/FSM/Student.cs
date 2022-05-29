using System.Collections;
using UnityEngine;

public enum StudentStates { RestAndSleep =0, StudyHard, TakeExam, PlayGame, HitTheBottle }
public class Student : BaseGameEntity
{
    private int knowledge;
    private int stress;
    private int fatigue;
    private int totalScore;
    private Locations currentLocations;

    private State[] states;
    private State currentState;
    public int Knowledge
    {
        set => knowledge = Mathf.Max(0, value);
        get => knowledge;
    }
    public int Stress
    {
        set => stress = Mathf.Max(0, value);
        get => stress;
    }
    public int Fatigue
    {
        set => fatigue = Mathf.Max(0, value);
        get => fatigue;
    }
    public int TotalScore
    {
        set => totalScore = Mathf.Max(0, value);
        get => totalScore;
    }
    public Locations CurrentLocations
    {
        set => currentLocations = value;
        get => currentLocations;
    }

    public override void Setup(string name)
    {
        base.Setup(name);

        gameObject.name = $"{ID:D2}_Student_{name}";

        states = new State[5];
        states[(int)StudentStates.RestAndSleep] = new StudentOwnedStates.RestAndSleep();
        states[(int)StudentStates.StudyHard] = new StudentOwnedStates.StudyHard();
        states[(int)StudentStates.TakeExam] = new StudentOwnedStates.TakeExam();
        states[(int)StudentStates.PlayGame] = new StudentOwnedStates.PlayGame();
        states[(int)StudentStates.HitTheBottle] = new StudentOwnedStates.HitTheBottle();
        
        ChangeState(StudentStates.RestAndSleep);

        knowledge = 0;
        stress = 0;
        fatigue = 0;
        totalScore = 0;
        currentLocations = Locations.SweetHome;

    }

    public void ChangeState(StudentStates newState)
    {
        if (states[(int)newState] == null) return;

        if( currentState != null)
        {
            currentState.Exit(this);
        }

        currentState = states[(int)newState];
        currentState.Enter(this);
    }
    public override void Updated()
    {
        if(currentState != null)
        {
            currentState.Execute(this);
        }
    }
}

