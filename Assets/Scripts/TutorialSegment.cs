using System;
using System.Collections.Generic;
using UnityEngine;

namespace ArioSoren.TutorialKit
{
    public class TutorialSegment : MonoBehaviour
    {
        public event Action<int> StepStarted;
        public event Action<int> StepPassed;
        public event Action<bool, int> TutorialStateChanged;

        [SerializeField] private List<TutorialStep> tutorialSteps;
        //public int lastStartedStep;
        //public int lastFinishedStep;
        public int CurrentStep = -1;


        private void Start()
        {
            Init();
        }
        public void NextStep()
        {
            HideStep(CurrentStep);
            CurrentStep++;
            //if (step <= lastFinishedStep && !fromInit) return;
            //if (step > lastStartedStep + 1) return;

            //if (fromInit)
            //{
            //    lastFinishedStep = step - 1;
            //}
            //var st = tutorialSteps.Find(s => s.Step == step);
            //if (st != null) st.ShowStep();
            tutorialSteps[CurrentStep].ShowStep();
            TutorialStateChanged?.Invoke(true, CurrentStep);
            StepStarted?.Invoke(CurrentStep);
        }

        public void HideStep(int step)
        {
            if (step < 0)
                return;
            //if (step <= lastFinishedStep) return;
            //if (step > lastStartedStep + 1) return;
            //var st = tutorialSteps.Find(s => s.Step == step);
            //if (st != null)
            tutorialSteps[step].HideStep();

            //OnStepPassed(step);
            StepPassed?.Invoke(step);

            TutorialStateChanged?.Invoke(false, step);
        }

        //public void SetStep(int lastStartedStep, int lastFinishedStep)
        //{
        //    //this.lastStartedStep = lastStartedStep;
        //    //this.lastFinishedStep = lastFinishedStep;
        //}

        //protected virtual void OnStepPassed(int step)
        //{
        //    //lastFinishedStep = step;
        //    StepPassed?.Invoke(step);

        //    TutorialStateChanged?.Invoke(false, step);

        //}

        //protected virtual void OnStepStarted(int step)
        //{
        //    //lastStartedStep = step;

        //}

        public void Init()
        {
            foreach (var step in tutorialSteps)
            {
                step.HideStep();
            }
            //if (lastFinishedStep < lastStartedStep)
            //{
                //var step = FindLastStartableStep(lastStartedStep);
                NextStep();
            //}
        }

        //public int FindLastStartableStep(int lastStep)
        //{
        //    while (true)
        //    {
        //        if (lastStep == 1) return 1;

        //        if (tutorialSteps.Find(s => s.Step == lastStep).Startable)
        //        {
        //            return lastStep;
        //        }

        //        lastStep -= 1;
        //    }
        //}
    }

    public enum HighlightType
    {
        CirculateAroundObject,
        AnimatedArrow,
        AnimatedHand,
    }

}