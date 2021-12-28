using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using FancyScrollView.Example09;

public class RecDB : MonoBehaviour
{
	//OptionSelect optionSelect;
	public string tvtype = "";
	public string tvsize = "";
	public string tvquality = "";
	public static string result = "";

	Example09 example09;
	TvChange tvchange;
	void Start()
    {
		example09 = GameObject.Find("Canvas").GetComponent<Example09>();
		tvchange = GameObject.Find("TVs").GetComponent<TvChange>();
    }

	void Update(){
		tvtype = OptionSelect.type;
		tvsize = OptionSelect.size;
		tvquality = OptionSelect.quality;
	}

	[SerializeField] string url;

	public void RecommendClick() => StartCoroutine(AccountCo("recommend"));

	public void LoginClick() => StartCoroutine(AccountCo("login"));

	public void RegisterClick() => StartCoroutine(AccountCo("register"));

	public void SaveClick() => StartCoroutine(AccountCo("save"));

	IEnumerator AccountCo(string command) 
	{
		Debug.Log(command+"버튼 클릭");
		Debug.Log(tvtype+","+tvsize+","+tvquality+"\n");

		WWWForm form = new WWWForm();

		form.AddField("command", command);
		form.AddField("tvtype", tvtype);
		form.AddField("size", tvsize);
		form.AddField("quality", tvquality);

		UnityWebRequest www = UnityWebRequest.Post(url, form);

		yield return www.SendWebRequest();
		// print(www.downloadHandler.text);
		result = www.downloadHandler.text;
		// print(result);
		example09.showScroll(result);
	}


}