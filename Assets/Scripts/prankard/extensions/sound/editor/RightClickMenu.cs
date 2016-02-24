using UnityEditor;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace scripts.prankard.extensions.sound.editor
{
	public static class RightClickMenu
	{
		//*
		[MenuItem("GameObject/RobotlegsExtension/Sound/Sound Effects Toggle Button", false, 30)]
		public static void SoundEffectsToggle()
		{
			CreatePrefab("Dummy");
		}

		[MenuItem("GameObject/RobotlegsExtension/Sound/Sound Music Toggle Button", false, 30)]
		public static void SoundMusicToggle()
		{
			
		}

		[MenuItem("GameObject/RobotlegsExtension/Sound/Sound Effects Slider", false, 30)]
		public static void SoundEffectsSlider()
		{

		}

		[MenuItem("GameObject/RobotlegsExtension/Sound/Sound Music Slider", false, 30)]
		public static void SoundMusicSlider()
		{

		}

		private static void CreatePrefab(string prefabName)
		{
			string path = Path.Combine(GetDirectory, prefabName + ".prefab");
			GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

			if (prefab == null)
				throw new UnityException("Cannot prefab at: " + path);

			Transform parent = Selection.activeTransform;
			GameObject instance = GameObject.Instantiate(prefab);
			instance.transform.SetParent(parent, false);

			string cloneString = "(Clone)";
			int cloneIndex = instance.name.LastIndexOf(cloneString);
			if (cloneIndex > 0)
				instance.name = instance.name.Substring(0, cloneIndex);
		}

		private static string GetDirectory
		{
			get
			{
				return "Assets/Scripts/prankard/extensions/sound/editor/";
			}
			//return AssetDatabase.GetAssetPath
		}
		//*/

		public static T[] GetAssetsOfType<T>(string fileExtension) where T : UnityEngine.Object
		{
			List<T> tempObjects = new List<T>();
			DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
			FileInfo[] goFileInfo = directory.GetFiles("*" + fileExtension, SearchOption.AllDirectories);

			int i = 0; int goFileInfoLength = goFileInfo.Length;
			FileInfo tempGoFileInfo; string tempFilePath;
			T tempGO;
			for (; i < goFileInfoLength; i++)
			{
				tempGoFileInfo = goFileInfo[i];
				if (tempGoFileInfo == null)
					continue;

				tempFilePath = tempGoFileInfo.FullName;
				tempFilePath = tempFilePath.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
				tempGO = AssetDatabase.LoadAssetAtPath(tempFilePath, typeof(T)) as T;
				if (tempGO == null)
				{
					continue;
				}
				else if (!(tempGO is T))
				{
					continue;
				}

				tempObjects.Add(tempGO);
			}

			return tempObjects.ToArray();
		}

	}
}