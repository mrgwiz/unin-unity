using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class UninClient : MonoBehaviour
{
    public string ENDPOINT = "";

    public void GetItemsForOwner(string owner) {
        StartCoroutine(ProcessRequest("GET", ENDPOINT + "/items/owner/" + owner, null, ProcessGetItemsForOwner));
    }

    public void GetItem(string id) {
        StartCoroutine(ProcessRequest("GET", ENDPOINT + "/items/" + id, null, ProcessGetItem));
    }

    private void ProcessGetItemsForOwner(JSONNode res, bool isSuccess) {
        Debug.Log("Result: " + res.ToString());
    }

    private void ProcessGetItem(JSONNode res, bool isSuccess) {
        Debug.Log("Result: " + res.ToString());
    }

    private IEnumerator ProcessRequest(
        string method,
        string url,
        string requestData = null,
        System.Action<JSONNode, bool> callback = null
    ) {
        Debug.Log("Request URL: " + url);
        Debug.Log("Request: " + requestData);

        using UnityWebRequest request = new UnityWebRequest(url, method);

        request.SetRequestHeader("Content-Type", "application/json");

        if (method == "POST" && requestData != null)
        {
            byte[] postData = new System.Text.UTF8Encoding().GetBytes(requestData);
            request.uploadHandler = new UploadHandlerRaw(postData);
        }

        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Response: " + request.error);
            JSONNode data = JSON.Parse(request.error);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
            JSONNode data = JSON.Parse(request.downloadHandler.text);
            callback?.Invoke(data, true);
        }
    }
}
