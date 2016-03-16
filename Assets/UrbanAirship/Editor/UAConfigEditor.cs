﻿/*
 Copyright 2016 Urban Airship and Contributors
*/

using System;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace UrbanAirship.Editor
{
	[InitializeOnLoad]
	public class UAConfigEditor : EditorWindow
	{
		private UAConfig config;

		[MenuItem ("Window/Urban Airship/Settings")]
		static void Init () {
			UAConfigEditor window = (UAConfigEditor) EditorWindow.GetWindow(typeof(UAConfigEditor), true, "Urban Airship Config");
			window.minSize = new Vector2(500, 400);
			window.Show();
		}

		void OnEnable()
		{
			config = UAConfig.LoadConfig();
		}

		void OnGUI()
		{
			GUILayout.Label ("Production App Credentials", EditorStyles.boldLabel);
			config.ProductionAppKey = EditorGUILayout.TextField("\t App Key", config.ProductionAppKey);
			config.ProductionAppSecret = EditorGUILayout.TextField("\t App Secret", config.ProductionAppSecret);

			GUILayout.Label ("Development App Credentials", EditorStyles.boldLabel);
			config.DevelopmentAppKey = EditorGUILayout.TextField("\t App Key", config.DevelopmentAppKey);
			config.DevelopmentAppSecret = EditorGUILayout.TextField("\t App Secret", config.DevelopmentAppSecret);

			GUILayout.Label ("Android", EditorStyles.boldLabel);
			config.GCMSenderId = EditorGUILayout.TextField("\t GCM Sender ID", config.GCMSenderId);

			GUILayout.Space(15);

			config.InProduction = EditorGUILayout.Toggle("inProduction", config.InProduction);

			GUILayout.Space(15);


			GUILayout.BeginHorizontal();

			if (GUILayout.Button("Cancel"))
			{
				Close();
			}

			GUILayout.FlexibleSpace();


			if (GUILayout.Button("Save"))
			{
				try
				{
					config.Validate();

					UnityEngine.Debug.Log ("Saving Urban Airship config.");

					config.Apply();
					UAConfig.SaveConfig(config);

					AssetDatabase.Refresh();
					Close();
				}
				catch (Exception e)
				{
					EditorUtility.DisplayDialog("Urban Airship", "Unable to save config. Erorr: " +  e.Message, "Ok");
				}
			}

			GUILayout.FlexibleSpace();

		}
	}
}
