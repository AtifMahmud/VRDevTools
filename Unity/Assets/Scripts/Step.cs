using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Step : MonoBehaviour
{
    /// <summary>
    /// User input to update the step number on the panel
    /// </summary>
    public string stepNumberText;

    /// <summary>
    /// User input to update the step title on the panel
    /// </summary>
    public string stepTitleText;

    /// <summary>
    /// User input to update the step description on the panel
    /// </summary>
    public string stepDescriptionText;

    /// <summary>
    /// A reference to the stepNumber UI component
    /// </summary>
    public TextMeshProUGUI stepNumber;

    /// <summary>
    /// A reference to the stepTitle UI component
    /// </summary>
    public TextMeshProUGUI stepTitle;

    /// <summary>
    /// A reference to the stepDescription UI component
    /// </summary>
    public TextMeshProUGUI stepDescription;

    /// <summary>
    /// A reference to the primary button UI component
    /// </summary>
    public Button primaryButton;

    /// <summary>
    /// A reference to secondary button UI component
    /// </summary>
    public Button secondaryButton;

    /// <summary>
    /// Event triggered when the user succeeds in this step
    /// </summary>
    public UnityEvent OnSuccessCallback;

    /// <summary>
    /// Event triggered when the user fails in this step
    /// </summary>
    public UnityEvent OnFailureCallback;

    /// <summary>
    /// Event triggered when step starts
    /// </summary>
    public UnityEvent OnStartupCallback;

    /// <summary>
    /// Event triggered when step ends
    /// </summary>
    public UnityEvent OnTeardownCallback;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Startup()
    {
        OnStartupCallback.Invoke();
    }

    public void Teardown()
    {
        OnTeardownCallback.Invoke();
    }

    /// <summary>
    /// Function to call when step is completed succesfully
    /// </summary>
    public void StepSuccess()
    {
        OnSuccessCallback.Invoke();
    }

    /// <summary>
    /// Function to call when step fails
    /// </summary>
    public void StepFailure()
    {
        OnFailureCallback.Invoke();
    }

    /// <summary>
    /// Updates the panel UI components with text input recieved on inspector
    /// </summary>
    public void UpdatePanelText()
    {
        stepNumber.text = stepNumberText;
        stepTitle.text = stepTitleText;
        stepDescription.text = stepDescriptionText;
    }
}
