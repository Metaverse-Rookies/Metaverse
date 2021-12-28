using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TestDB : MonoBehaviour
{
	[SerializeField] InputField tvtypeInput;
	[SerializeField] InputField sizeInput;
	[SerializeField] InputField qualityInput;

	[SerializeField] string url;

	public void LoginClick() => StartCoroutine(AccountCo("login"));

	public void RegisterClick() => StartCoroutine(AccountCo("register"));

	public void SaveClick() => StartCoroutine(AccountCo("save"));

	IEnumerator AccountCo(string command) 
	{
		WWWForm form = new WWWForm();

		form.AddField("command", command);
		form.AddField("tvtype", tvtypeInput.text);
		form.AddField("size", sizeInput.text);
		form.AddField("quality", qualityInput.text);

		UnityWebRequest www = UnityWebRequest.Post(url, form);

		yield return www.SendWebRequest();
		print(www.downloadHandler.text);
	}
}