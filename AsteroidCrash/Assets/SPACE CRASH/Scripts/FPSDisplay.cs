using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour
{
	[SerializeField]
	private TMPro.TMP_Text text;

	float deltaTime = 0.0f;
	bool toggle;

	// see: http://wiki.unity3d.com/index.php/FramesPerSecond
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			toggle = !toggle;
		}

		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		text.text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);

		if (toggle)
			text.enabled = true;
		else
			text.enabled = false;
	}

}