using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TimeBehaviourSingleton))]
public class TimeBehaviourSingletonEditor : Editor {
	TimeBehaviourSingleton src = null;
	
	bool bigTime = false;
	
	public override void OnInspectorGUI() {
		src = target as TimeBehaviourSingleton;
		//base.OnInspectorGUI();
		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();
		bigTime = EditorGUILayout.Toggle("Do you want to use huge Time Scales ?", bigTime);
		if (bigTime)
			src._secondsToCompleteADay = EditorGUILayout.Slider("Duration of a day in seconds", src._secondsToCompleteADay, 60f, 86400f);
		else
			src._secondsToCompleteADay = EditorGUILayout.Slider("Duration of a day in seconds", src._secondsToCompleteADay, .001f, 60f);
		EditorGUILayout.EndHorizontal();
		src._rushHours = EditorGUILayout.CurveField(new GUIContent("The disposition of the Rush hours during the day", "Horizontal value HAS to be between 0 and 24, Vertical indicates the number of people that should be on the screen at this time."), src._rushHours);
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		src.useGenerosityOverTime = EditorGUILayout.Toggle("Do you want to use Changing generosity over time ?", src.useGenerosityOverTime);
		if (src.useGenerosityOverTime)
			src._generosity = EditorGUILayout.CurveField(new GUIContent("The disposition of the generosity during the day", "Horizontal value HAS to be between 0 and 24, Vertical is the chance in percent that any given NPC will give money"), src._generosity);
		
	}
}
