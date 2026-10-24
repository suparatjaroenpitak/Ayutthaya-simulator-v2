using System.IO;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace AyutthayaSimulator.Editor
{
    public static class SomchaiAnimatorControllerBuilder
    {
        private static readonly string[] ClipNames = { "Idle", "Walk", "Run", "Jump", "Interact", "Sit", "Sleep", "Farm" };
        [MenuItem("Ayutthaya/Animation/Create Somchai Placeholder Controller")]
        public static void Create()
        {
            Directory.CreateDirectory("Assets/Animation/Somchai");
            const string controllerPath = "Assets/Animation/Somchai/Somchai.controller";
            if (File.Exists(controllerPath)) AssetDatabase.DeleteAsset(controllerPath);
            AnimatorController controller = AnimatorController.CreateAnimatorControllerAtPath(controllerPath);
            AddParameters(controller);
            AnimatorStateMachine root = controller.layers[0].stateMachine;
            AnimatorState[] states = new AnimatorState[ClipNames.Length];
            for (int i = 0; i < ClipNames.Length; i++)
            {
                AnimationClip clip = new AnimationClip { name = "Placeholder_" + ClipNames[i] };
                string clipPath = "Assets/Animation/Somchai/Placeholder_" + ClipNames[i] + ".anim";
                AssetDatabase.CreateAsset(clip, clipPath);
                AnimatorState state = root.AddState(ClipNames[i]);
                states[i] = state;
                state.motion = AssetDatabase.LoadAssetAtPath<AnimationClip>(clipPath);
                if (ClipNames[i] == "Idle") root.defaultState = state;
            }
            AddTransitions(root, states);
            AssetDatabase.SaveAssets();
            Selection.activeObject = controller;
            Debug.Log("Created Somchai placeholder controller. Replace placeholder clips only with licensed/owned animation assets.");
        }

        private static void AddTransitions(AnimatorStateMachine root, AnimatorState[] states)
        {
            AnimatorState idle = states[0], walk = states[1], run = states[2], jump = states[3];
            AnimatorState interact = states[4], sit = states[5], sleep = states[6], farm = states[7];
            AnimatorStateTransition idleToWalk = idle.AddTransition(walk); idleToWalk.hasExitTime = false; idleToWalk.AddCondition(AnimatorConditionMode.Greater, 0.1f, "Speed");
            AnimatorStateTransition walkToIdle = walk.AddTransition(idle); walkToIdle.hasExitTime = false; walkToIdle.AddCondition(AnimatorConditionMode.Less, 0.1f, "Speed");
            AnimatorStateTransition walkToRun = walk.AddTransition(run); walkToRun.hasExitTime = false; walkToRun.AddCondition(AnimatorConditionMode.If, 0, "Running");
            AnimatorStateTransition runToWalk = run.AddTransition(walk); runToWalk.hasExitTime = false; runToWalk.AddCondition(AnimatorConditionMode.IfNot, 0, "Running");
            AnimatorStateTransition jumpTransition = root.AddAnyStateTransition(jump); jumpTransition.hasExitTime = false; jumpTransition.AddCondition(AnimatorConditionMode.Less, 0, "VerticalVelocity");
            AnimatorStateTransition interactTransition = root.AddAnyStateTransition(interact); interactTransition.hasExitTime = false; interactTransition.AddCondition(AnimatorConditionMode.If, 0, "Interact");
            AnimatorStateTransition sitTransition = root.AddAnyStateTransition(sit); sitTransition.hasExitTime = false; sitTransition.AddCondition(AnimatorConditionMode.If, 0, "Sit");
            AnimatorStateTransition sleepTransition = root.AddAnyStateTransition(sleep); sleepTransition.hasExitTime = false; sleepTransition.AddCondition(AnimatorConditionMode.If, 0, "Sleep");
            AnimatorStateTransition farmTransition = root.AddAnyStateTransition(farm); farmTransition.hasExitTime = false; farmTransition.AddCondition(AnimatorConditionMode.If, 0, "Farm");
            interact.AddExitTransition(0.9f);
            jump.AddExitTransition(0.9f);
        }

        private static void AddParameters(AnimatorController controller)
        {
            controller.AddParameter("Speed", AnimatorControllerParameterType.Float);
            controller.AddParameter("Grounded", AnimatorControllerParameterType.Bool);
            controller.AddParameter("Running", AnimatorControllerParameterType.Bool);
            controller.AddParameter("VerticalVelocity", AnimatorControllerParameterType.Float);
            controller.AddParameter("Interact", AnimatorControllerParameterType.Trigger);
            controller.AddParameter("Sit", AnimatorControllerParameterType.Bool);
            controller.AddParameter("Sleep", AnimatorControllerParameterType.Bool);
            controller.AddParameter("Farm", AnimatorControllerParameterType.Bool);
        }
    }
}
