using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class ButtonOn : MonoBehaviour
{
	public Button buttonOn;
	public Button buttonOff;

	void Start()
	{
		Button btnOn = buttonOn.GetComponent<Button>();
		btnOn.onClick.AddListener(TaskOnClick1);
		Button btnOff = buttonOff.GetComponent<Button>();
		btnOff.onClick.AddListener(TaskOnClick2);
    }

	void TaskOnClick1()
	{
		Debug.Log("You have clicked the button on!");
        StartCoroutine(TurnOnLED());
    }

	void TaskOnClick2()
	{
		Debug.Log("You have clicked the button off!");
        StartCoroutine(TurnOffLED());
    }

    IEnumerator TurnOnLED()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post("https://api.particle.io/v1/devices/e00fce68fbf5c55ce7fe8567/light?access_token=28600544f109558175412813a3fbfa0e0ddbdb9d", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

    IEnumerator TurnOffLED()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post("https://api.particle.io/v1/devices/e00fce68fbf5c55ce7fe8567/dark?access_token=28600544f109558175412813a3fbfa0e0ddbdb9d", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
