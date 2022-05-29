using System.Collections;
using UnityEngine;

namespace StudentOwnedStates
{
    public class RestAndSleep : State
    {

        public override void Enter(Student entity)
        {
            entity.CurrentLocations = Locations.SweetHome;
            entity.Stress = 0;

            entity.PrintText("집");
        }
        public override void Execute(Student entity)
        {
            entity.PrintText("Zzz");

            if (entity.Fatigue > 0)
            {
                entity.Fatigue -= 10;
            }
            else
            {
                entity.ChangeState(StudentStates.StudyHard);
            }
        }
        public override void Exit(Student entity)
        {
            entity.PrintText("나가자");
        }
    }

    public class StudyHard : State
    {
        public override void Enter(Student entity)
        {
            entity.CurrentLocations = Locations.Library;

            entity.PrintText("공부");
        }

        public override void Execute(Student entity)
        {
            entity.PrintText("공부 공부 공부 ");
            entity.Knowledge++;
            entity.Stress++;
            entity.Fatigue++;

            if(entity.Knowledge >= 3 && entity.Knowledge <= 10)
            {
                int isExit = Random.Range(0, 2);
                if(isExit ==1 || entity.Knowledge ==10)
                {
                    entity.ChangeState(StudentStates.TakeExam);
                }
            }
            if(entity.Stress >= 20)
            {
                entity.ChangeState(StudentStates.PlayGame);
            }
            if(entity.Fatigue >=20)
            {
                entity.ChangeState(StudentStates.RestAndSleep);
            }
        }

        public override void Exit(Student entity)
        {
            entity.PrintText("집가");
        }
    }

    public class TakeExam :State

    {
        public override void Enter(Student entity)
        {
            entity.CurrentLocations = Locations.LectureRoom;

            entity.PrintText("강의실");
        }
        public override void Execute(Student entity)
        {
            int examScore = 0;

            if (entity.Knowledge == 10)
            {
                examScore = 10;
            }
            else
            {
                int randomIndex = Random.Range(0, 10);
                examScore = randomIndex < entity.Knowledge ? Random.Range(6, 11) : Random.Range(1, 6);
            }

            entity.Knowledge = 0;
            entity.Fatigue += Random.Range(5, 11);

            entity.TotalScore += examScore;
            entity.PrintText($"시험성적{examScore}, 총점 {entity.TotalScore}");

            if(entity.TotalScore >= 100)
            {
                GameController.Stop(entity);
                return;
            }

            if (examScore <= 3)
            {

            }    
            else if(examScore <= 7)
            {
                entity.ChangeState(StudentStates.StudyHard);
            }
            else
            {
                entity.ChangeState(StudentStates.PlayGame);
            }
        }

        public override void Exit(Student entity)
        {
            entity.PrintText("나간다");
        }
    }

    public class PlayGame : State
    {
        public override void Enter(Student entity)
        {
            entity.CurrentLocations = Locations.PCRoom;

            entity.PrintText("놀자");
        }

        public override void Execute(Student entity)
        {
            entity.PrintText("게임중");

            int randState = Random.Range(0, 10);
            if(randState == 0 || randState == 9)
            {
                entity.Stress += 20;

                entity.ChangeState(StudentStates.HitTheBottle);
            }
            else
            {
                entity.Stress--;
                entity.Fatigue += 2;
                if(entity.Stress<=0)
                {
                    entity.ChangeState(StudentStates.StudyHard);
                }
            }
        }

        public override void Exit(Student entity)
        {
            entity.PrintText("PC방을 나간다");
        }
    }

    public class HitTheBottle : State
    {
        public override void Enter(Student entity)
        {
            entity.CurrentLocations = Locations.Pub;

            entity.PrintText("술먹자");
        }
        public override void Execute(Student entity)
        {
            entity.PrintText("술을 먹는다");

            entity.Stress -= 5;
            entity.Fatigue += 5;

            if (entity.Stress <= 0 || entity.Fatigue >= 50)
            {
                entity.ChangeState(StudentStates.RestAndSleep);
            }
        }
        public override void Exit(Student entity)
        {
            entity.PrintText("그만 마시고 집가자");
        }
    }
}



