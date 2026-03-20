using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class managerEu : MonoBehaviour {

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    GameObject pai;
    Vector3 eixoP0World;
    Vector3 eixoP1World;
    Vector3 eixoP2World;
    Vector3 eixoP3World;
    int[] tetraredrosMeioEixoP3 = new int[] { 3, 4, 8, 12, 18, 22 };
    int[] tetraredrosBaseEixoP3 = new int[] { 0, 1, 2, 6, 7, 9, 10, 11, 13, 14, 15, 16, 17, 19, 20, 21 };



    Vector3 m_Center;
	// Use this for initialization
	void Start () {

		for(int i=0; i < 24; i++)
        {
            if(i == 0)
            {
                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(0, 0, 0), Quaternion.identity); // tetraedro base
                vetGameObj[i].name = i.ToString();
            }
            else
                vetGameObj[i]= Instantiate(tetrahedron, new Vector3(vetGameObj[i-1].transform.position.x + 1, 0, 0), vetGameObj[i - 1].transform.rotation);
                vetGameObj[i].name = i.ToString();

            //i-1 posicao anterior
        }

        // NORMAIS
        vetGameObj[3].transform.position = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);
        vetGameObj[4].transform.position = new Vector3(1 + 0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);
        vetGameObj[5].transform.position = new Vector3(1, 2*Mathf.Sqrt(0.75f), 2*Mathf.Sqrt(0.75f) / 3);
        vetGameObj[6].transform.position = new Vector3(1 + 0.5f, 0, Mathf.Sqrt(0.75f));
        vetGameObj[7].transform.position = new Vector3(1 , 0, 2* Mathf.Sqrt(0.75f));
        vetGameObj[8].transform.position = new Vector3(1, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) + Mathf.Sqrt(0.75f) / 3);
        vetGameObj[9].transform.position = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));

        // INVERTIDOS FACE FRONTAL
        vetGameObj[10].transform.position = new Vector3(1.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3); // posicao do tetraedro 4
        vetGameObj[10].transform.Rotate(37f, 0f, 180f);
        vetGameObj[11].transform.position = new Vector3(2.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3); // posicao do lado do tetraedro 4
        vetGameObj[11].transform.Rotate(37f, 0f, 180f);
        vetGameObj[12].transform.position = new Vector3(2, 2 * Mathf.Sqrt(0.75f), 2 * Mathf.Sqrt(0.75f) / 3); // posicao do lado do tetraedro 5
        vetGameObj[12].transform.Rotate(37f, 0f, 180f);

        // INVERTIDOS FACE DE BAIXO
        vetGameObj[13].transform.position = new Vector3(1.5f, 0, Mathf.Sqrt(0.75f)); // posicao do tetraedro 6
        vetGameObj[13].transform.Rotate(0f, 180f, 0f);
        vetGameObj[14].transform.position = new Vector3(2.5f, 0, Mathf.Sqrt(0.75f)); // posicao do tetraedro do lado do 6
        vetGameObj[14].transform.Rotate(0f, 180f, 0f);
        vetGameObj[15].transform.position = new Vector3(2, 0, 2 * Mathf.Sqrt(0.75f)); // posicao do lado do 7
        vetGameObj[15].transform.Rotate(0f, 180f, 0f);

        // INVERTIDOS FACE ESQUERDA
        pai = new GameObject("paiRotacoes");

        vetGameObj[16].transform.position = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3); // posicao do tetraedro 3
        pai.transform.position = new Vector3(1f, 0.86603f, 0.28868f + Mathf.Sqrt(3) / 2); // pai no p2 do tetraedro 16
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[16].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[16].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        vetGameObj[17].transform.position = new Vector3(0f, 0.86603f, -0.28868f * 2);
        pai.transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[17].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[17].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        vetGameObj[18].transform.position = new Vector3(0.5f, 0.86603f * 2, -0.28868f);
        pai.transform.position = new Vector3(1f, 0.86603f * 2, 0.28868f * 2);
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[18].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[18].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        // INVERTIDOS FACE DIREITA

        vetGameObj[19].transform.position = new Vector3(0.5f * 4, 0.86603f, -0.28868f * 2);
        pai.transform.position = new Vector3(0.5f * 5, 0.86603f, 0.28868f);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[19].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[19].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        vetGameObj[20].transform.position = new Vector3(0.5f * 3, 0.86603f, 0.28868f);
        pai.transform.position = new Vector3(0.5f * 4, 0.86603f, 0.28868f + Mathf.Sqrt(3) / 2);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[20].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[20].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        vetGameObj[21].transform.position = new Vector3(0.5f * 3, 0.86603f, 0.28868f);
        pai.transform.position = new Vector3(0.5f * 4, 0.86603f, 0.28868f + Mathf.Sqrt(3) / 2);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[21].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[21].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        vetGameObj[22].transform.position = new Vector3(0.5f * 3, 0.86603f * 2, -0.28868f);
        pai.transform.position = new Vector3(2f, 0.86603f * 2, 0.28868f * 2);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[22].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[22].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        // PARTE 1: COMPUTAR 4 EIXOS DE ROTAÇÃO =============================================================================

        // COMPUTAR BARICENTRO = SOMAR OS X,Y,Z DE CADA PONTO DA PIRÂMIDE E DIVIDIR POR 4
        float x = (0 + 3 + 1.5f + 1.5f) / 4f;
        float y = (0 + 0 + 0 + 3*Mathf.Sqrt(0.75f)) / 4f;
        float z = (0 + 0 + 3*Mathf.Sqrt(0.75f) + (3*Mathf.Sqrt(0.75f)/3) ) / 4f;

        Vector3 baricentro = new Vector3(x, y, z);


        // COMPUTAR EIXOS EM CADA VÉRTICE = VÉRTICE - BARICENTRO
        Vector3 P0 = new Vector3(0, 0, 0);
        Vector3 P1 = new Vector3(3, 0, 0);
        Vector3 P2 = new Vector3(1.5f, 0, 3 * Mathf.Sqrt(0.75f));
        Vector3 P3 = new Vector3(1.5f, 3 * Mathf.Sqrt(0.75f), (3 * Mathf.Sqrt(0.75f) / 3));

        Vector3 eixoP0 = (P0 - baricentro).normalized;
        eixoP0World = eixoP0.normalized;
        Vector3 eixoP1 = (P1 - baricentro).normalized;
        eixoP1World = eixoP1.normalized;
        Vector3 eixoP2 = (P2 - baricentro).normalized;
        eixoP2World = eixoP2.normalized;
        Vector3 eixoP3 = (P3 - baricentro).normalized; // esse é o Eixo Vertical
        eixoP3World = eixoP3.normalized;

        // comentado, pois estou chamando a função no update
        //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosBaseEixoP3, 120, eixoP3World);


    }

    // Baricentro local do tetraedro = média dos 4 vértices locais.
    private Vector3 CalcularBaricentroLocal(Vector3[] verticesLocal)
    {
        if (verticesLocal == null || verticesLocal.Length != 4)
        {
            Debug.LogError("Um tetraedro precisa de exatamente 4 vértices.");
            return Vector3.zero;
        }

        Vector3 soma = Vector3.zero;

        for (int i = 0; i < 4; i++)
        {
            soma += verticesLocal[i];
        }

        return soma / 4f;
    }

    // Retorna o baricentro do tetraedro em coordenadas globais.
    private Vector3 CalcularBaricentroWorld(GameObject tetra)
    {
        criarTetra ct = tetra.GetComponent<criarTetra>();
        if (ct == null)
        {
            Debug.LogError("O GameObject " + tetra.name + " não possui createTetra.");
            return Vector3.zero;
        }

        Vector3[] verticesLocal = ct.getVectors();
        Vector3 baricentroLocal = CalcularBaricentroLocal(verticesLocal);

        return tetra.transform.TransformPoint(baricentroLocal);
    }

    // Calcula o baricentro da lista de tetraedros.
    // Como todos são tetraedros equivalentes, usamos a média
    // dos baricentros globais dos tetraedros do grupo.
    public Vector3 CalcularBaricentroListaTetraedros(int[] indices)
    {
        Vector3 soma = Vector3.zero;
        int totalValidos = 0;

        for (int i = 0; i < indices.Length; i++)
        {
            int idx = indices[i];

            soma += CalcularBaricentroWorld(vetGameObj[idx]);
            totalValidos++;

        }

        if (totalValidos == 0)
        {
            Debug.LogError("Nenhum tetraedro válido foi encontrado no grupo.");
            return Vector3.zero;
        }

        return soma / totalValidos;
    }

    // Rotaciona o grupo em torno de um eixo que passa pelo baricentro da lista de tetraedros
    public void RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(int[] indices, float anguloGraus, Vector3 eixo)
    {

        // Ponto por onde o eixo passa
        Vector3 baricentroGrupo = CalcularBaricentroListaTetraedros(indices);

        // Rotaciona todos os tetraedros do grupo ao redor desse eixo
        for (int i = 0; i < indices.Length; i++)
        {
            int idx = indices[i];
            vetGameObj[idx].transform.RotateAround(
                baricentroGrupo,
                eixo,
                anguloGraus
            );

        }
    }

    // Update is called once per frame
    void Update () {
        //aqui chama rotacionar 
        RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(
                                                                tetraredrosBaseEixoP3,
                                                                30f * Time.deltaTime,
                                                                eixoP3World);
        RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(
                                                                tetraredrosMeioEixoP3,
                                                                40f * Time.deltaTime,
                                                                eixoP3World);
    }
}
