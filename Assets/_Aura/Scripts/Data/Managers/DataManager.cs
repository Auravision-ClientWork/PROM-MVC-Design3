using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;

/// <summary>
/// Commits new patient data via the SaveAndLoadSystem, retrieves data via the SaveAndLoad system,
/// performs queries using LINQ
/// presents data to the Userinterface via a UI Controller
/// </summary>
public class DataManager : MonoBehaviour
{
    //cache of the info of the current patient being evaluated 
    private PatientInfo currentPatient;
    [SerializeField]private int currentPatientAk;
    [SerializeField]private string currentPatientVisitDate;
    [SerializeField] private string currentPatientComorbidities;
    [SerializeField] private string currentPatientComplaints;
    [SerializeField] private string currentPatientRegion;
    [SerializeField] private float currentPatientScore;


    public static DataManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void CommitBioData(int _ak, string _visitDate, string _comorbidities = null, string complaints = null)
    {
        //ToDo: adds ak number, visit date,comorbidities and complaints to the currentPatient object 
        currentPatientAk = _ak;
        currentPatientVisitDate = _visitDate;
        currentPatientComorbidities = _comorbidities;
        currentPatientComplaints = complaints;
    }

    public void CommitRegionData(string _region)
    {
        //ToDo: adds region, score data to the currentPatientObject
        currentPatientRegion = _region;    
    }

    public void CommitScoreData(float _score)
    {
        currentPatientScore = _score;
    }

    private void SaveCurrentPatientData()
    {
        //ToDo: speaks to the SaveAndLoadSystem to save/serialize the current patient data

        //creates a patientInfo object with all the cached data
        PatientInfo newPatient = new PatientInfo(currentPatientAk, currentPatientVisitDate,
            currentPatientRegion, currentPatientComorbidities,
            currentPatientComplaints, currentPatientScore);

        //passes this newPatient object to the SaveAndLoadSystem for serialization.
        SaveLoadSystem.SavePatientInfo(newPatient);

    }

    #region Test Utility
    //public void TestCommitInfo(int _ak, string _visitDate, string _region, string _comorbidities, string _complaints, float _score)
    //{
    //    currentPatientComorbidities = new List<string>();
    //    currentPatientComorbidities.Add(_comorbidities);

    //    currentPatientComplaints = new List<string>();
    //    currentPatientComplaints.Add(_complaints);

    //    currentPatientAk = _ak;
    //    currentPatientVisitDate = _visitDate;
    //    currentPatientRegion = _region;
    //    currentPatientScore = _score;

    //    SaveCurrentPatientData();
    //}
    //public string TestRetrieveInfo(int _ak)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    string retrievedInfo = "";
        
    //    if( SaveLoadSystem.RetrievePatientInfo(out  Dictionary<int, List<PatientInfo>> data))
    //    {
    //        //return patient akNo,region, and score
    //        if (data.ContainsKey(_ak))
    //        {
    //            data.TryGetValue(_ak, out List<PatientInfo> value);
    //            foreach (var item in value)
    //            {
    //                sb.AppendLine(item.akNo+ " | "+item.VisitDate + " | "+ item.Score);
    //            }
    //            retrievedInfo = sb.ToString();
    //            return retrievedInfo;
    //        }
    //        else
    //        {
    //            retrievedInfo = "No such patient in system!";
    //            return retrievedInfo;
    //        }
    //    }
    //    else
    //    {
    //        retrievedInfo = "You patient data in system"!;
    //        return retrievedInfo;
    //    }
       
    //} 

    #endregion
}
