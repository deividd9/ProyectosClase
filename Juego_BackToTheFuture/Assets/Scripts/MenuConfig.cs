using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuConfig : MonoBehaviour
{
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSFX;
    [SerializeField] Text textMusic;
    [SerializeField] Text textSFX;
    // Start is called before the first frame update
    void Start()
    {
        sliderMusic.value = GameManager.volumeMusic;
        textMusic.text = GameManager.volumeMusic.ToString();

        sliderSFX.value = GameManager.volumeSFX;
        textSFX.text = GameManager.volumeSFX.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume()
    {
        textMusic.text = sliderMusic.value.ToString();
        GameManager.volumeMusic = (int)sliderMusic.value;

        PlayerPrefs.SetInt("V_MUSIC", (int)sliderMusic.value);
    }
    public void UpdateSFX()
    {
        textMusic.text = sliderSFX.value.ToString();
        GameManager.volumeMusic = (int)sliderSFX.value;

        PlayerPrefs.SetInt("V_MUSIC", (int)sliderMusic.value);
    }
}
