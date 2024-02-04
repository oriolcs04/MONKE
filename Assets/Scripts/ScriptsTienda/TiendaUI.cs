using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaUI : MonoBehaviour
{
    private int totalObject;
    [SerializeField] private GameObject panelEquipo;

    #region TIENDA

    
    
    
    public void AdqirirObjeto(string objeto)
    {
        if (totalObject <3)
        {
            totalObject++;
            GameObject equipo = (GameObject)Resources.Load(objeto);
            Instantiate(equipo, Vector3.zero, Quaternion.identity, panelEquipo.transform);
        }
       
  
    }

    #endregion
}
