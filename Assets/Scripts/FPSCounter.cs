using UnityEngine;

public class FPSCounter : MonoBehaviour
{
	private const float updateInterval = 0.5f;

	private float time = 0.0f;
	private int frames = 0;
	private float timeToUpdate;
	private float fps;

	private readonly GUIStyle textStyle = new GUIStyle();

	private void Start()
	{
		timeToUpdate = updateInterval;
		textStyle.fontStyle = FontStyle.Bold;
		textStyle.normal.textColor = Color.white;
	}

	private void Update()
	{
		timeToUpdate -= Time.deltaTime;
		time += Time.deltaTime;
		++frames;

		if (timeToUpdate <= 0.0)
		{
			fps = 1.0f / (time / frames);
			
			time = 0.0f;
			frames = 0;
			timeToUpdate = updateInterval;
		}
	}

	private void OnGUI()
	{
		textStyle.fontSize = 20;
		GUI.Label(new Rect(5, 5, 120, 30), fps.ToString("F2") + " FPS", textStyle);
	}
}