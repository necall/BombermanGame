using UnityEngine;
using System.Collections;

namespace FutureCartographer.Apples.Demo
{
	public class AppleSample : MonoBehaviour
	{
		public GameObject prefabNormalApple;
		public GameObject prefabBiteApple;


		public float biteRate = 0.3f;
		public float rotateSpeed = 15.0f;
		public float instantiatePeriod = 2.0f;

		private float poptime;

		void Start()
		{
			poptime = 0;
		}

		void Update()
		{
			// camera rotate
			transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f);

			poptime += Time.deltaTime;

			// popup new apples
			if (poptime > instantiatePeriod)
			{
				poptime -= instantiatePeriod;

				Vector3 pos = new Vector3(Random.Range(-8.0f, 8.0f), 22.0f, Random.Range(-8.0f, 8.0f));
				Quaternion rot = Quaternion.Euler(Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f));

				if (Random.Range(0.001f, 0.999f) < biteRate)
				{
					// bite apple
					Instantiate(prefabBiteApple, pos, rot);
				}
				else
				{
					// normal apple
					Instantiate(prefabNormalApple, pos, rot);
				}
			}
		}
	}
}
