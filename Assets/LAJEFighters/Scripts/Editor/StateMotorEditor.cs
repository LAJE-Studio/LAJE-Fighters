using System;
using System.Collections.Generic;
using System.Linq;
using LAJEFighters.Scripts.Entity.Movement.States;
using UnityEditor;
using UnityEngine;
using UnityUtilities;
using UnityUtilities.Editor;

namespace LAJEFighters.Scripts.Editor {
    public class StateSelectorContent : PopupWindowContent {
        private const float Width = 200;
        private readonly StateMotor motor;
        private readonly List<Type> knownStateTypes = TypeUtility.GetAllTypesOf<MovementState>().ToList();

        public StateSelectorContent(StateMotor motor) {
            this.motor = motor;
        }

        public override Vector2 GetWindowSize() {
            var height = EditorGUIUtility.singleLineHeight * knownStateTypes.Count;
            return new Vector2(Width, height);
        }

        public override void OnGUI(Rect rect) {
            var data = knownStateTypes;
            for (var i = 0; i < data.Count; i++) {
                var s = data[i];
                var pos = rect.GetLine((uint) i, EditorGUIUtility.singleLineHeight);
                //GUI.enabled = s.Valid;
                var type = s;
                if (!GUI.Button(pos, type.Name)) {
                    continue;
                }

                var instance = (MovementState) motor.AddToAssetFile(type);
                instance.name = type.Name;
                motor.AddState(instance);
            }
        }
    }

    public static class RectUtil {
        public static Rect GetLine(this Rect rect, uint collum, uint totalLines = 1, float yOffset = 0F) {
            return rect.GetLine(collum, EditorGUIUtility.singleLineHeight, totalLines, yOffset);
        }

        public static Rect GetLine(
            this Rect rect,
            uint collum,
            float collumHeight,
            uint totalLines = 1,
            float yOffset = 0F) {
            var height = totalLines * collumHeight;
            return rect.GetLine(collum, height, collumHeight, yOffset);
        }

        private static Rect GetLine(
            this Rect rect,
            uint collum,
            float height,
            float collumHeight,
            float yOffset = 0F) {
            return rect.SubRect(rect.width, height, yOffset: collum * collumHeight + yOffset);
        }

        public static Rect SubRect(this Rect rect, float width, float height, float xOffset = 0F, float yOffset = 0F) {
            return new Rect(rect.x + xOffset, rect.y + yOffset, width, height);
        }

        public static void Split(this Rect rect, float splitPosition, out Rect a, out Rect b) {
            a = rect.SubRect(splitPosition, rect.height);
            b = rect.SubRect(rect.width - splitPosition, rect.height, splitPosition);
        }
    }

    [CustomEditor(typeof(StateMotor))]
    public class StateMotorEditor : UnityEditor.Editor {
        private StateSelectorContent stateSelector;
        private StateMotor motor;

        private void OnEnable() {
            motor = (StateMotor) target;
            stateSelector = new StateSelectorContent(motor);
        }

        public override void OnInspectorGUI() {
            var e = Event.current;
            var states = motor.States;
            //motor.DefaultState = (MovementState) EditorGUILayout.ObjectField("Default State", motor.DefaultState, typeof(State), false);
            //motor.CollisionMask = UPMEditor.LayerMaskField("Collision Mask", motor.CollisionMask);
            var notEmpty = states.Count > 0;
            EditorGUILayout.PrefixLabel((notEmpty ? states.Count.ToString() : "No") + " states found");

            if (notEmpty) {
                var toRemove = new List<MovementState>();
                foreach (var state in states) {
                    EditorGUILayout.BeginHorizontal();
                    state.name = EditorGUILayout.TextField(state.name);
                    if (GUILayout.Button("Delete")) {
                        toRemove.Add(state);
                    }

                    EditorGUILayout.EndHorizontal();
                }

                foreach (var state in toRemove) {
                    motor.RemoveState(state);
                    DestroyImmediate(state, true);
                }
            }

            if (!GUILayout.Button("Add State")) {
                return;
            }

            var rect = new Rect(e.mousePosition, stateSelector.GetWindowSize());
            PopupWindow.Show(rect, stateSelector);
        }
    }
}