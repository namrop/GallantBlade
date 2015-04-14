using UnityEngine;
using System.Collections;

namespace Gallant_Blade
{
	public class attackController : MonoBehaviour {

		public GameObject BaseAttack;
		private GameObject attack;
		public float duration;
		private float timer;
		private bool active;
		private Transform attack_transform;
		private bool facing_right;
		// Use this for initialization
		void Start () {
			active = false;
			facing_right = true;
		
		}

		private Vector3 attack_pos(){
			if (facing_right) 
			{
			return transform.position + new Vector3 (2, 0, 0);
			}
			return transform.position + new Vector3 (-2, 0, 0);
		}
		
		// Update is called once per frame
		void Update () {
			if (!active) {
				return;
			}
			timer += Time.deltaTime;
			attack.transform.position = attack_pos();
			if (timer >= duration) {
				Destroy(attack);
				active = false;
				timer = 0f;
			}
		
		}

		public void swing(){
			if (active) {
				return;
			}
			attack = Instantiate (BaseAttack, attack_pos(), Quaternion.identity) as GameObject;
			active = true;
		}

		public void Flip(){
			facing_right = !facing_right;
		}
	}
}