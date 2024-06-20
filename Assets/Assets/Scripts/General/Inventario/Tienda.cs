using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu]
public class Tienda : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventario inventario;
    public Inventario jugador;
    public GameObject contenedor;
    public GameObject contenedorVenta;
    [SerializeField] GameObject objeto;
    [SerializeField] ListaObjetos listaObjetos;
    [SerializeField] List<Lista> compra = new List<Lista>();
    [SerializeField] List<Lista> venta = new List<Lista>();
    [SerializeField] TextMeshProUGUI oro;
    void Start()
    {
        inventario.oro = 0;
        inventario.inv = new List<Lista> {
        new Lista {id = 0, cantidad=50},
        new Lista {id = 1, cantidad=30},
        new Lista {id = 2, cantidad=180},
        };
        oro.text = jugador.oro.ToString();
        rellenarContenedores();
    }

    public void transaccion()
    {
        int Costo = 0;
        foreach(Transform child in contenedor.transform)
        {
            Lista objetoComprado = new Lista();
            objetoComprado.id = child.GetComponent<InvUiObj>().getId();
            objetoComprado.cantidad = child.GetComponent<InvUiObj>().getCantidad();
            if(objetoComprado.cantidad > 0)
            {
                compra.Add(objetoComprado);
            }
            Costo += child.GetComponent<InvUiObj>().getCantidad() * child.GetComponent<InvUiObj>().getPrecio();
        }

        foreach(Transform child in contenedorVenta.transform)
        {
            Lista objetoComprado = new Lista();
            objetoComprado.id = child.GetComponent<InvUiObj>().getId();
            objetoComprado.cantidad = child.GetComponent<InvUiObj>().getCantidad();
            venta.Add(objetoComprado);
            int costoproducto = child.GetComponent<InvUiObj>().getCantidad() * child.GetComponent<InvUiObj>().getPrecio();
            Debug.Log(costoproducto - Mathf.Ceil(costoproducto * 0.20f));
            Costo -= (int)(costoproducto - Mathf.Ceil(costoproducto * 0.20f));
        }
        
        if((jugador.oro-Costo) >= 0)
        {
            jugador.addItem(compra);
            jugador.removeItem(venta);
            jugador.oro -= Costo;
            compra.Clear();
            venta.Clear();
            oro.text = jugador.oro.ToString();
            rellenarContenedores();
        }
    }

    void rellenarContenedores()
    {
        Vector3 position = transform.position;
        foreach(Transform child in contenedor.transform) {
            Destroy(child.gameObject);
        }

        foreach(Transform child in contenedorVenta.transform) {
            Destroy(child.gameObject);
        }

        foreach(Lista objetoinstanciar in jugador.inv)
        {
            GameObject nombre = Instantiate(objeto,new Vector3(position.x,position.y,position.z),Quaternion.identity);
            nombre.transform.SetParent(contenedorVenta.transform);
            nombre.GetComponent<InvUiObj>().setNombre(listaObjetos.inventario[objetoinstanciar.id].prefab.name);
            nombre.GetComponent<InvUiObj>().setImage(listaObjetos.inventario[objetoinstanciar.id].sprite);
            nombre.GetComponent<InvUiObj>().setPrecio(listaObjetos.inventario[objetoinstanciar.id].precio.ToString());
            nombre.GetComponent<InvUiObj>().setId(objetoinstanciar.id);
            nombre.GetComponent<InvUiObj>().setMax(objetoinstanciar.cantidad);
            nombre.GetComponent<InvUiObj>().setCantidad(objetoinstanciar.cantidad.ToString());
        }

        foreach(Lista objetoinstanciar in inventario.inv)
        {
            GameObject nombre = Instantiate(objeto,new Vector3(position.x,position.y,position.z),Quaternion.identity);
            nombre.transform.SetParent(contenedor.transform);
            nombre.GetComponent<InvUiObj>().setNombre(listaObjetos.inventario[objetoinstanciar.id].prefab.name);
            nombre.GetComponent<InvUiObj>().setImage(listaObjetos.inventario[objetoinstanciar.id].sprite);
            nombre.GetComponent<InvUiObj>().setPrecio(listaObjetos.inventario[objetoinstanciar.id].precio.ToString());
            nombre.GetComponent<InvUiObj>().setId(objetoinstanciar.id);
            nombre.GetComponent<InvUiObj>().setMax(objetoinstanciar.cantidad);
        }
    }

}
