using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score Data")]
public class GenericSO : ScriptableObject
{
    [field:SerializeField]public float ScorePaResponse { get; private set; }
    [field:SerializeField]public float BestScore { get; private set; }
    [field:SerializeField]public float WorstScore { get; private set; }
    [field: SerializeField] public bool isIncrementing { get; private set; }

    [NonReorderable]
    public SectionStrucure[] sections;

    public int GetResponseCount(int _sectionCount)
    {
        return sections[_sectionCount].responses.Length;
    }

    public string GetSectionPrompt(int _sectionCount)
    {
        return sections[_sectionCount].prompt;
    }

    public string GetReponse(int _sectionCount,int _responseCount)
    {
        return sections[_sectionCount].responses[_responseCount];
    }

    public SectionStrucure[] GetSections()
    {
        return sections;
    }
}
