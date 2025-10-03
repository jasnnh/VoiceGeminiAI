using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Http;
using TMPro;
using LeastSquares.Undertone;
using UnityEngine.UI;

public class GeminiAI : SingletonInstance<GeminiAI>
{
    public TextMeshProUGUI replyData;
    public RealtimeTranscriber rt;
    public TMP_InputField q;
    public int job;
    public RealtimeRecordButtonUndertone btn;
    public Text replyData2;
    public TMP_InputField job_title;
    public GameObject resume;
    public int useResume = 0;

    [TextAreaAttribute] string displayAnswer;
    
    void Start()
    {

    }

    public void btnResume(TMP_Dropdown d)
    {
        useResume = d.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            btn.OnClicked();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(Lookup(q.text));
            rt.StopListening();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            openBrowser();
        }
    }

    public void inquire()
    {
        Debug.Log("inquire: " + q.text);
        StartCoroutine(Lookup(q.text));
        rt.StopListening();
    }

    IEnumerator Lookup(string d)
    {
        replyData.text = "";

        if (!string.IsNullOrEmpty(job_title.text))
        {
            d = d + " related to job title " + job_title.text;
        }
        else
        {
			
        }


        using (UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1/AI.php?data=" + d))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("unfiltered: " + www.downloadHandler.text);

                string data = www.downloadHandler.text;
                string r = data.Replace('"', ' ');
                string[] dd = r.Split("text :");
                string[] ddd = dd[1].Split("}");
                string[] s = ddd[0].Split(char.Parse("\\"));
                for(int i = 0; i < s.Length; i++)
                {
                    replyData.text = replyData.text + "\r\n" + s[i].Substring(1) + "\r\n";
                    replyData2.text = replyData2.text + "\r\n" + s[i].Substring(1) + "\r\n";
                }


            } 

        }
    }

    public void openBrowser()
    {
        Application.OpenURL("https://www.google.com/search?q=" + q.text);
    }

    public void promptResume()
    {
        if (resume.activeInHierarchy)
        {
            resume.SetActive(false);
        }
        else
        {
            resume.SetActive(true);
        }
    }

    public class JsonObject
    {
        public string candidates;
        public string content;
    }

    public void jobIndustry(TMP_Dropdown d)
    {
        job = d.value;
        Debug.Log(job);
    }
}
