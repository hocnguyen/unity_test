using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using NCMB;

public class MainActivity : MonoBehaviour {
	public Text result;
	// Use this for initialization
	void Start () {
		Debug.Log("start");
		result.text = "Start";
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void testClick(){
				  
		Debug.Log("Button Push !!");
        NCMBInstallation installation = NCMBInstallation.getCurrentInstallation();
        Debug.Log("★★ApplicationName=" + installation.ApplicationName);
        Debug.Log("★★DeviceToken=" + installation.DeviceToken);
        Debug.Log("★★DeviceType=" + installation.DeviceType);
        Debug.Log("★★ObjectId=" + installation.ObjectId);

        //NCMBInstallation curInstallation = NCMBInstallation.getCurrentInstallation();
        installation.Add("region", "Asia");
        installation.SaveAsync((NCMBException e) => {
            if (e != null)
            {
                //成功時の処理
                Debug.Log("Button Push エラー !!" + e.ToString());
            }
            else
            {
                //エラー時の処理
                Debug.Log("Button Push 成功 !!");
            }

        });


		
		/*NCMBInstallation installation2 =   NCMBInstallation.getCurrentInstallation();
        result.text = "ObjectId "+installation2.ObjectId + " deviceToken "+installation2.DeviceToken;*/
		/*NCMBInstallation installation = new NCMBInstallation ();
		installation.Add ("region", "Asia");
		installation.SaveAsync ((NCMBException e)=>{
		    if(e!=null){
		        if (e.ErrorMessage.Equals ("Duplication Error")) {
						NCMBQuery<NCMBInstallation> query = NCMBInstallation.GetQuery ();	//ObjectId検索
						query.WhereEqualTo ("deviceToken", installation.DeviceToken);
						query.FindAsync ((List<NCMBInstallation> objList, NCMBException findError) => {
							if (objList.Count != 0) {
								installation.ObjectId = objList [0].ObjectId;
								installation.SaveAsync ((NCMBException installationUpdateError) => {
									
								});
							}
						});
					} 
		    } else {
		        //エラー時の処理
		    }
		});*/
	}



	void OnApplicationPause(bool pauseStatus) {
		result.text = "OnPause";
    }

    void OnApplicationFocus(bool focusStatus) {
		result.text = "OnFocus";
    }

}
