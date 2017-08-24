using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunUnityChanController : MonoBehaviour {

	// [SerializeField]を記述すると、privateメンバの値がインスペクタから設定可能になる
	[SerializeField]
	private UnityChanController unityChanController;

	[SerializeField]
	private GameObject obstaclePrefab;
	private float elapsedTime = 0.0f;

	private bool isGameOver = false;

	// Update is called once per frame
	// Update等のUnityメインループが呼ぶメソッドはprivateでも呼び出される(修飾子ない場合はprivate)
	void Update () {
		if ( this.isGameOver ) {
			return;
		}

		if ( Input.GetMouseButtonDown(0) ) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			// レイキャストでレイがヒットしているかを調べる
			if ( Physics.Raycast(ray, out raycastHit) ) {
				// ヒットしたgameObjectが[UnityChan]というtagを持っているか調べる
				if ( raycastHit.transform.gameObject.tag.Contains("UnityChan") ) {
					// unityChanControllerにタップされた事を通知(OnTappedイベントハンドラを呼び出し)
					this.unityChanController.OnTapped();
				}
			}
		}

		elapsedTime += Time.deltaTime;

		// 3.5 秒に一回、obstaclePrefabをインスタンス化し配置
		if ( 2.5f <= elapsedTime ) {
			GameObject obstacle = Instantiate(this.obstaclePrefab);
			ObstacleController obstacleController = obstacle.GetComponent<ObstacleController>();
			obstacleController.CollidedWithUnityChan += this.ObstacleCollidedWithUnityChan;
			obstacle.transform.position = new Vector3(0.0f, 0.0f, 3.0f);
			elapsedTime = 0.0f;
		}
	}

	private void ObstacleCollidedWithUnityChan () {
		if ( this.isGameOver ) {
			return;
		}
        this.unityChanController.OnCollidedWithObstacle();
        this.isGameOver = true;
	}
}
