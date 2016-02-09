using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class SaveLoad : MonoBehaviour {

	public bool hasLoad = false;

	void Awake()
	{
		this.Load();
	}

	public void Save()
	{
		this.hasLoad = true;
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/MenuInfo.dat");
		itemsToStore data = new itemsToStore();

		data.hasLoad = this.hasLoad;

		bf.Serialize (file, data);
		file.Close();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/MenuInfo.dat")) {

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/MenuInfo.dat", FileMode.Open);
			itemsToStore data = (itemsToStore)bf.Deserialize (file);
			file.Close ();

			this.hasLoad = data.hasLoad;
		}
	}

	public class itemsToStore
	{
		public bool hasLoad;
	}
}
