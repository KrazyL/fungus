﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fungus
{
	[System.Serializable]
	public class StringVar
	{
		public string key;
		public string value;
	}

	[System.Serializable]
	public class IntVar
	{
		public string key;
		public int value;
	}

	[System.Serializable]
	public class FloatVar
	{
		public string key;
		public float value;
	}

	[System.Serializable]
	public class BoolVar
	{
		public string key;
		public bool value;
	}

	[System.Serializable]
	public class SavePointData
	{
		public string sceneName;
		public string flowchartName;
		public string resumeBlockName;

		public List<StringVar> stringVars = new List<StringVar>();
		public List<IntVar> intVars = new List<IntVar>();
		public List<FloatVar> floatVars = new List<FloatVar>();
		public List<BoolVar> boolVars = new List<BoolVar>();

        public static void ResumeSavedState(SavePointData saveData)
        {
            var go = GameObject.Find(saveData.flowchartName);
            if (go == null)
            {
                return;
            }

            var flowchart = go.GetComponent<Flowchart>();
            if (flowchart == null)
            {
                return;
            }

            for (int i = 0; i < saveData.boolVars.Count; i++)
            {
                var boolVar = saveData.boolVars[i];
                flowchart.SetBooleanVariable(boolVar.key, boolVar.value);
            }
            for (int i = 0; i < saveData.intVars.Count; i++)
            {
                var intVar = saveData.intVars[i];
                flowchart.SetIntegerVariable(intVar.key, intVar.value);
            }
            for (int i = 0; i < saveData.floatVars.Count; i++)
            {
                var floatVar = saveData.floatVars[i];
                flowchart.SetFloatVariable(floatVar.key, floatVar.value);
            }
            for (int i = 0; i < saveData.stringVars.Count; i++)
            {
                var stringVar = saveData.stringVars[i];
                flowchart.SetStringVariable(stringVar.key, stringVar.value);
            }

            flowchart.ExecuteBlock(saveData.resumeBlockName);
        }
	}
}