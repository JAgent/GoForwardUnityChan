using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10;

	public AudioClip audioClip;

	private AudioSource audioSource;

	// Use this for initialization
	void Start(){
	}

	// Update is called once per frame
	void Update () {
		// キューブを移動させる
		transform.Translate (this.speed, 0, 0);

		// 画面外に出たら破棄する
		if (transform.position.x < this.deadLine){
			Destroy (gameObject);
		}
	}

	//トリガーモードで他のオブジェクトと接触した場合の処理（追加）
	void OnCollisionEnter2D(Collision2D other) {

		//障害物に衝突した場合

		audioSource = GetComponent<AudioSource>();
		audioSource.Play ();
		if (other.gameObject.tag == "CubeTag" || other.gameObject.tag == "groundTag") {
			// 地面に接触したとき／ブロック同士が衝突したときにボリュームを上げる
			GetComponent<AudioSource> ().volume = 1;
		} else {
			if (other.gameObject.tag == "UnityChan2DTag") {
				// 地面に接触したとき／ブロック同士が衝突したときにボリュームを上げる
				GetComponent<AudioSource> ().volume = 0;
			} else {
				GetComponent<AudioSource> ().volume = 0;

			}
		}

	}
}