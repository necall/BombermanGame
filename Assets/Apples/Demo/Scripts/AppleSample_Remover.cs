using UnityEngine;
using System.Collections;

namespace FutureCartographer.Apples.Demo
{
	public class AppleSample_Remover : MonoBehaviour
	{
		void OnTriggerEnter(Collider other)
		{
			Destroy(other.gameObject);
		}
	}
}
