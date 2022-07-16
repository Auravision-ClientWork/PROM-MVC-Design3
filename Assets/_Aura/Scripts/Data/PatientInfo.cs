using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PatientInfo 
{
    public readonly int akNo;
    public string VisitDate { get; set; }
    public string Region { get; set; }  
    public List<string> Comorbidities { get; set; }
    public List<string> Complaints { get; set; }

    public float Score { get;private set; }

    public PatientInfo (int akNo, string visitDate, string region, List<string> comorbidities = null, List<string> complaints = null, float score = 0)
    {
        this.akNo = akNo;
        VisitDate = visitDate;
        Region = region;
        Comorbidities = comorbidities;
        Complaints = complaints;
        Score = score;
    }
}
public enum Regions
{
    Cervical,
    UpperLimb,
    Back,
    Hip,
    Knee,
    FootAndAnkle
}

[System.Serializable]
public class SectionStrucure
{
    [TextArea(2,4)]public string prompt;
  [NonReorderable] [TextArea(2,4)] public string[] responses;
}
