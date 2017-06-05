using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Reflection;

[assembly: AssemblyVersionAttribute("4.3.2.1")]
namespace DesignLibrary { }

public class Destroyer : MonoBehaviour {

	void DestroyGameObject()
    {
        Debug.Log("A fost apelat Destroyer");
        Destroy(gameObject);
    }

}
