using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;


public static class SaveLoadSystem
{
    public static void SavePatientInfo(PatientInfo newPatient)
    {
        //do we have this patient in our dictionary/saved file?
        //if so get that info so we can add to it the new data
        int ak = newPatient.akNo;

        List<PatientInfo> dataForAk = new List<PatientInfo>();
        Dictionary<int, List<PatientInfo>> patientData;

        if (RetrievePatientInfo(out patientData))//a condition that will be true only after the first run of the app
        {
            if (patientData.ContainsKey(ak))
            {
                //this patient file exists
                //get the list attached, add the new info
                patientData.TryGetValue(ak, out List<PatientInfo> value);
                value.Add(newPatient);
            }
            else
            {
                //this patient file does not exist
                //add the incoming info to the new list
                //add the file to the data
                dataForAk.Add(newPatient);
                patientData.Add(ak, dataForAk);

            }
        }
        else //first run of the app
        {
            patientData = new Dictionary<int, List<PatientInfo>>();
            dataForAk.Add(newPatient);
            patientData.Add(ak, dataForAk);
        }

        //convert the dictionary to a json string
        string patientDataString = JsonConvert.SerializeObject(patientData, Formatting.Indented);
        //serialize the string
        Debug.Log("Serializing: " + patientDataString);
        SerializeInfo(patientDataString);

    }


    public static bool RetrievePatientInfo(out Dictionary<int, List<PatientInfo>> patientData)
    {
        Dictionary<int, List<PatientInfo>> retrievedData = new Dictionary<int, List<PatientInfo>>();
        //look into the saved binary file for data related to the incoming akNo
        string retrievedInfo = DeserializeInfo();
        //convert back to dictionary
        if (!string.IsNullOrEmpty(retrievedInfo))
        {
            retrievedData = JsonConvert.DeserializeObject<Dictionary<int, List<PatientInfo>>>(retrievedInfo);
            patientData = retrievedData;
            return true;
        }
        else
        {
            Debug.Log("No saved file!");
            patientData = null;
            return false;
        }

    }
    private static void SerializeInfo(string patientDataString)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/patientdata.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, patientDataString);
        stream.Close();
    }

    private static string DeserializeInfo()
    {
        string path = Application.persistentDataPath + "/patientdata.data";
        string info = null;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            info = (string)formatter.Deserialize(stream);
            stream.Close();
            return info;
        }
        else
        {
            return info;
        }
    }
}
