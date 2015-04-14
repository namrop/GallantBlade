using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets;

namespace Gallant_Blade {
	public class HealthDialog : MonoBehaviour {

		private Text instruction;
		public PlatformerCharacter2D player;
		private int health;

		// Use this for initialization
		void Start () {
			instruction = GetComponent<Text>();
		}
		
		// Update is called once per frame
		void Update () {

			instruction.text = "Health: " + player.Health.ToString();
		
		}
	}
}