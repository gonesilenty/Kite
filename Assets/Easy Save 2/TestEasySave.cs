using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEasySave : SingletonMono<TestEasySave> 
{
	public void Save(string modelName, List<string> modelSaveList)
	{
		ES2.Save (modelSaveList, Application.dataPath + "/save.txt?tag=" + modelName);
	}	

	public List<string> GetSaveList(string modelName)
	{	
		if (ES2.Exists (Application.dataPath + "/save.txt?tag=" + modelName)) {
			List<string> loadStringList = ES2.LoadList<string> (Application.dataPath + "/save.txt?tag=" + modelName);

			return loadStringList;
		} else
			return null;
	}		
}
