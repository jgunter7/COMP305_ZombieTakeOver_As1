using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*      File Name:              MenuController.cs
 *      Author's Name:          Jason Gunter
 *      Last Modified By:       Jason Gunter
 *      Date Last Modified:     Oct 2nd, 2016
 *      Program Description:    A 2D scrolling game
 *      File Description:       This script controls the start menu, 
 *                              and starting the "Main" game scene.
 *      Revision History:       https://github.com/jgunter7/COMP305_ZombieTakeOver_As1
 */
public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartButton_Click() {
        // Start the "Main" game scene
        SceneManager.LoadScene("Main");
    }
}
