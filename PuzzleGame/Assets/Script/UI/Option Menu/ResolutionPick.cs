using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResolutionPick : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resulutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> resolutionList;

    private int currentRefreshRate;
    private int currentResulutionIndex = 0;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionList = new List<Resolution>();

        resulutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                resolutionList.Add(resolutions[i]);
            }
        }
        List<string> option = new List<string>();
        for (int i = 0; i < resolutionList.Count; i++)
        {
            string resolutionOption = resolutionList[i].width + "x" + resolutionList[i].height;//;+ " " + resolutionList[i].refreshRateRatio + " Hz";
            option.Add(resolutionOption);
            if (resolutionList[i].width == Screen.width && resolutionList[i].height == Screen.height)
            {
                currentResulutionIndex = i;
            }

        }

        resulutionDropdown.AddOptions(option);
        resulutionDropdown.value = currentResulutionIndex;
        resulutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutionList[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
