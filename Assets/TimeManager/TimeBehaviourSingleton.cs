using UnityEngine;

public class TimeBehaviourSingleton : MonoBehaviour {
	public static TimeBehaviourSingleton Instance { get; private set; }
	public static AnimationCurve RushHours { get { return TimeBehaviourSingleton.Instance._rushHours; } }
	public static float SecondsToCompleteADay { get { return TimeBehaviourSingleton.Instance._secondsToCompleteADay; } }
	
	public static float PredictedNumberOfPeopleOnScreen { get { return RushHours.Evaluate(Instance.time*24f); } }
	
	public static bool UseGenerosityOverTime { get { return TimeBehaviourSingleton.Instance.useGenerosityOverTime; } }
	public static AnimationCurve Generosity { get { return TimeBehaviourSingleton.Instance._generosity; } }
	public static float ActualNPCGenerosity { get { return Generosity.Evaluate(Instance.time*24f); } }
	
	public AnimationCurve _rushHours = null;
	public float _secondsToCompleteADay = 1;
	
	public bool useGenerosityOverTime = false;
	public AnimationCurve _generosity = null;
	
	private float time = 0;
	
	
	protected void Awake() {
		if (Instance != null) 
			Debug.LogErrorFormat("ERROR : There cannot be two instances of 'TimeBehaviourSingleton', instance {0} tries to override {1} !", this.gameObject.name, Instance.gameObject.gameObject.name);
			
		Instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	
	protected void Update() {
		time += Time.deltaTime / _secondsToCompleteADay;
		if (time > 1) 
			time -= 1;
	}
}
