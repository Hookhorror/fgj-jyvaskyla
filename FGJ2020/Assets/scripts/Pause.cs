using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    private string pauseButton = "PauseButton";
    public readonly string startScreenName = "StartingScreen";
    public GUIStyle guiStyle;
    public Texture napinKuva;

    void Update()
    {
        if (Input.GetButtonDown(pauseButton))
            paused = TogglePause();
    }

    void Awake()
    {
    }

    //tekee guielementin uuteen horizontal tilaan keskitettynä. Jos onkolabelvaibutton on true niin se on label. falsella button.
    //Palauttaa buttonin vastauksen tai sit false labelistä
    bool guiElement(bool onkoLabelVaiButton ,string jono,GUIStyle tyyli)
    {
        if (onkoLabelVaiButton)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(jono, tyyli);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            return false;
        }

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        bool vastaus = GUILayout.Button(jono,tyyli);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        return vastaus;

    }

    void OnGUI()
    {
        if (paused)
        {
            //tehdään pausevalikko ja sille alue johon lisätään elementtejä
            int leveys = 430;
            int korkeus = 200;
            GUILayout.BeginArea(new Rect(Screen.width / 2f - leveys/2f, Screen.height / 2f - korkeus/2f, leveys, korkeus));
            GUILayout.BeginVertical();
            guiElement(true, "Game is paused!",guiStyle);
            GUILayout.Space(25f);
            
            if (guiElement(false,"Resume",guiStyle))
                paused = TogglePause();
            if (guiElement(false, "Main menu", guiStyle))
            {
                TogglePause();
                UnityEngine.SceneManagement.SceneManager.LoadScene(startScreenName);
            }
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }

    //Muuttaa kaikkien soivien äänilähteiden soittonopeutta haluttuun. Käytetään äänien pysäyttämiseen kun pausetetaan.
    void muutaAania(float soittoNopeus)
    {
        //varmistetaan että aika kulkee eteenpäin
        if(soittoNopeus >= 0f)
        {
            object[] lista = AudioSource.FindObjectsOfType(typeof(AudioSource));
            foreach (AudioSource aani in lista)
            {
                //kokeilin pausea ja playtä mutta ne ei jostakin syystä nopeasti toimineet, niin toi toistonopeuden muuttaminen nollaan käy pausesta hyvin
                aani.pitch = soittoNopeus;
            }
        }
    }

    bool TogglePause()
    {
        //timescale siis voidaan käyttää hidastukseen, mutta tässä tapauksessa sitä käytetään pelin pauselle pistämiseen.
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            muutaAania(1f);
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            muutaAania(0f);
            return (true);
        }
    }
}
