using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

[CustomEditor(typeof(Step))]
public class StepInspector : Editor
{
    /// <summary>
    /// Small spacing in pixels to separate inspector elements
    /// </summary>
    private const float SMALL_VERTICAL_SPACE = 2;

    /// <summary>
    /// Medium spacing in pixels to separate inspector elements
    /// </summary>
    private const float MEDIUM_VERTICAL_SPACE = 5;

    /// <summary>
    /// A reference to the stepNumber TextMeshProUGUI on the Step class
    /// </summary>
    SerializedProperty stepNum;

    /// <summary>
    /// A reference to the stepTitle TextMeshProUGUI on the Step class
    /// </summary>
    SerializedProperty stepTitle;

    /// <summary>
    /// A reference to the stepDescription TextMeshProUGUI on the Step class
    /// </summary>
    SerializedProperty stepDescription;

    /// <summary>
    /// A reference to the primaryButton on the Step class
    /// </summary>
    SerializedProperty primaryButton;
    
    /// <summary>
    /// A reference to the secondaryButton on the Step class
    /// </summary>
    SerializedProperty secondaryButton;

    /// <summary>
    /// A reference to the onSuccessCallback UnityEvent on the Step class
    /// </summary>
    SerializedProperty onSuccessCallback;

    /// <summary>
    /// A reference to the onFailureCallback UnityEvenet on the Step class
    /// </summary>
    SerializedProperty onFailureCallback;

    SerializedProperty onStartupCallback;

    SerializedProperty onTeardownCallback;

    /// <summary>
    /// Boolean to control foldout that hides TMPro components of the panel
    /// </summary>
    private bool tmProFoldout;

    public void OnEnable()
    {
        /** UI elements **/
        stepNum = serializedObject.FindProperty("stepNumber");
        stepTitle = serializedObject.FindProperty("stepTitle");
        stepDescription = serializedObject.FindProperty("stepDescription");
        primaryButton = serializedObject.FindProperty("primaryButton");
        secondaryButton = serializedObject.FindProperty("secondaryButton");

        /** Callbacks, events **/
        onSuccessCallback = serializedObject.FindProperty("OnSuccessCallback");
        onFailureCallback = serializedObject.FindProperty("OnFailureCallback");
        onStartupCallback = serializedObject.FindProperty("OnStartupCallback");
        onTeardownCallback = serializedObject.FindProperty("OnTeardownCallback");
    }

    /// <summary>
    /// TODO: Add elements to make button editing easier
    /// </summary>
    public override void OnInspectorGUI()
    {
        Step step = (Step)target;

        /** Text Input: Step Number **/
        GUIContent stepNumberTextContent = new GUIContent("Step Number", "Enter the step number or an identifier to display on top of the panel");
        step.stepNumberText = EditorGUILayout.TextField(stepNumberTextContent, step.stepNumberText);
        EditorGUILayout.Space(SMALL_VERTICAL_SPACE);

        /** Text Input: Step Title **/
        GUIContent stepTitleTextContent = new GUIContent("Step Title", "Enter the text to display as the title of the panel");
        step.stepTitleText = EditorGUILayout.TextField(stepTitleTextContent, step.stepTitleText);
        EditorGUILayout.Space(SMALL_VERTICAL_SPACE);

        /** Text Input: Step Description **/
        // TODO: Enable multi-line text
        GUIContent stepDescriptionTextContent = new GUIContent("Step Description", "Enter the text to display as the instructions for the step");
        step.stepDescriptionText = EditorGUILayout.TextField(stepDescriptionTextContent, step.stepDescriptionText, GUILayout.Height(200));
        EditorGUILayout.Space(SMALL_VERTICAL_SPACE);

        /** Button: Apply changes from the above to the panel **/
        GUIContent applyChangesButtonContent = new GUIContent("Apply changes to panel", "Update the panel with text you entered above");
        if (GUILayout.Button(applyChangesButtonContent, GUILayout.Height(20)))
        {
            step.UpdatePanelText();
        }

        EditorGUILayout.Space(MEDIUM_VERTICAL_SPACE);

        /** Startup Events **/
        GUIContent onStartupCallbackContent = new GUIContent("On Startup Events", "Functions to execute when step starts");
        EditorGUILayout.PropertyField(onStartupCallback, onStartupCallbackContent);
        EditorGUILayout.Space(MEDIUM_VERTICAL_SPACE);

        /** Teardown Events **/
        GUIContent onTeardownCallbackContent = new GUIContent("On Teardown Events", "Functions to execute when step ends");
        EditorGUILayout.PropertyField(onTeardownCallback, onTeardownCallbackContent);
        EditorGUILayout.Space(MEDIUM_VERTICAL_SPACE);

        /** Success Event **/
        GUIContent onCompleteCallbackContent = new GUIContent("On Success Events", "Functions to execute when step is successfully completed");
        EditorGUILayout.PropertyField(onSuccessCallback, onCompleteCallbackContent);
        EditorGUILayout.Space(MEDIUM_VERTICAL_SPACE);

        /** Failure Event **/
        GUIContent onFailureCallbackContent = new GUIContent("On Failure Events", "Functions to execute when step fails");
        EditorGUILayout.PropertyField(onFailureCallback, onFailureCallbackContent);
        EditorGUILayout.Space(MEDIUM_VERTICAL_SPACE);

        /** Foldout of the TMPro components **/
        GUIContent tmproFoldoutContent = new GUIContent("UI Components", "Reference to the TMPro UI components");
        tmProFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(tmProFoldout, tmproFoldoutContent);
        if (tmProFoldout)
        {
            EditorGUILayout.LabelField("Panel UI Components", EditorStyles.boldLabel);
            EditorGUILayout.Space(SMALL_VERTICAL_SPACE);

            GUIContent stepNumberContent = new GUIContent("Step Number UI", "A reference to the TMPro component displaying the step number");
            EditorGUILayout.PropertyField(stepNum, stepNumberContent);

            GUIContent stepTitleContent = new GUIContent("Step Title UI", "A reference to the TMPro component displaying the step title");
            EditorGUILayout.PropertyField(stepTitle, stepTitleContent);

            GUIContent stepDescriptionContent = new GUIContent("Step Description UI", "A reference to the TMPro component displaying the step description");
            EditorGUILayout.PropertyField(stepDescription, stepDescriptionContent);

            GUIContent primaryButtonContent = new GUIContent("Primary Button", "A reference to the button bound to primary action");
            EditorGUILayout.PropertyField(primaryButton, primaryButtonContent);

            GUIContent secondaryButtonContent = new GUIContent("Secondary Button", "A reference to the button bound to secondary action");
            EditorGUILayout.PropertyField(secondaryButton, secondaryButtonContent);
        }

        EditorGUILayout.EndFoldoutHeaderGroup();
        serializedObject.ApplyModifiedProperties();
    }
}
