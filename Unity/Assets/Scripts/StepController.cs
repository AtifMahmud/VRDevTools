using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    public List<Step> steps = new List<Step>();

    [HideInInspector]
    public int stepNumber = 0;

    private Step _currentStep;

    public Step CurrentStep
    {
        get { return _currentStep; }
        set { _currentStep = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartStepController()
    {
        Step firstStep = steps[0];
        firstStep.Startup();
        _currentStep = firstStep;
    }

    public void AdvanceStep()
    {
        _currentStep.Teardown();
        stepNumber++;
        _currentStep = steps[stepNumber];
        _currentStep.Startup();
    }
}
