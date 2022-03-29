using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.EventSystems;



public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject OptionMenu;
  

    [SerializeField] AudioMixer audioMixer;

    [SerializeField] GameObject volumeSlider;

    [SerializeField] TMP_Dropdown QualityDropdown;
    [SerializeField] TMP_Dropdown ResolutionDropdown;


    Resolution[] resolutions;

    // Start is called before the first frame update
     void Start()
    {
        mainMenu.SetActive(true);
        OptionMenu.SetActive(false);

        QualityDropdown.value = QualitySettings.GetQualityLevel();

        ResolutionDropdown.ClearOptions(); 

        resolutions = Screen.resolutions;
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "X" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettingsMenu()
    {
        OptionMenu.SetActive(true);
        mainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(volumeSlider);

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
        Debug.Log(fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void CloseOptionMenu()
    {
        mainMenu.SetActive(true);
        OptionMenu.SetActive(false);
    }

    

}
