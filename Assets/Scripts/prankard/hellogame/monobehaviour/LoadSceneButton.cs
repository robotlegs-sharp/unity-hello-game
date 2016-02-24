using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour {

	[SerializeField] private string sceneName;

	public void OnClick()
	{
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}
}
