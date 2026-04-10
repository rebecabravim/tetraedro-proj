using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class managerEu : MonoBehaviour {

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[22];
    public GameObject plano;

    GameObject planoTP0;
    GameObject planoMP0;
    GameObject planoBP0;

    GameObject planoTP1;
    GameObject planoMP1;
    GameObject planoBP1;

    GameObject planoTP2;
    GameObject planoMP2;
    GameObject planoBP2;

    GameObject planoTP3;
    GameObject planoMP3;
    GameObject planoBP3;

    

    GameObject pai;
    Vector3 eixoP0World;
    Vector3 eixoP1World;
    Vector3 eixoP2World;
    Vector3 eixoP3World;

    int[] tetraredrosTopoEixoP0 = new int[] { 0 };
    int[] tetraredrosMeioEixoP0 = new int[] { 1, 3, 9, 10, 13, 17 };
    int[] tetraredrosBaseEixoP0 = new int[] { 2, 4, 5, 6, 7, 8, 11, 12, 14, 15, 16, 18, 19, 20, 21 };

    int[] tetraredrosTopoEixoP1 = new int[] { 2 };
    int[] tetraredrosMeioEixoP1 = new int[] { 1, 4, 6, 11, 14, 19 };
    int[] tetraredrosBaseEixoP1 = new int[] { 0, 3, 5, 7, 8, 9, 10, 12, 13, 15, 16, 17, 18, 20, 21 };

    int[] tetraredrosTopoEixoP2 = new int[] { 7 };
    int[] tetraredrosMeioEixoP2 = new int[] { 6, 8, 9, 15, 16, 20 };
    int[] tetraredrosBaseEixoP2 = new int[] { 0, 1, 2, 3, 4, 5, 10, 11, 12, 13, 14, 17, 18, 19, 21 };

    int[] tetraredrosTopoEixoP3 = new int[] { 5 };
    int[] tetraredrosMeioEixoP3 = new int[] { 3, 4, 8, 12, 18, 21 };
    int[] tetraredrosBaseEixoP3 = new int[] { 0, 1, 2, 6, 7, 9, 10, 11, 13, 14, 15, 16, 17, 19, 20 };



    Vector3 m_Center;
	// Use this for initialization
	void Start () {

        //planoTP3 = Instantiate(plano, new Vector3(0, 2.4f, 0), Quaternion.identity);
        //planoMP3 = Instantiate(plano, new Vector3(0, 1.4f, 0), Quaternion.identity);
        //planoBP3 = Instantiate(plano, new Vector3(0,0.4f,0), Quaternion.identity);



        for (int i=0; i < 22; i++)
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
        pai.transform.Rotate(Vector3.right, 37f);
        vetGameObj[16].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        vetGameObj[17].transform.position = new Vector3(0f, 0.86603f, -0.28868f * 2);
        pai.transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[17].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 37f);
        vetGameObj[17].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        vetGameObj[18].transform.position = new Vector3(0.5f, 0.86603f * 2, -0.28868f);
        pai.transform.position = new Vector3(1f, 0.86603f * 2, 0.28868f * 2);
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[18].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 37f);
        vetGameObj[18].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        // INVERTIDOS FACE DIREITA

        vetGameObj[19].transform.position = new Vector3(0.5f * 4, 0.86603f, -0.28868f * 2);
        pai.transform.position = new Vector3(0.5f * 5, 0.86603f, 0.28868f);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[19].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 37f);
        vetGameObj[19].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        vetGameObj[20].transform.position = new Vector3(0.5f * 3, 0.86603f, 0.28868f);
        pai.transform.position = new Vector3(0.5f * 4, 0.86603f, 0.28868f + Mathf.Sqrt(3) / 2);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[20].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 37f);
        vetGameObj[20].transform.parent = null;
        pai.transform.rotation = Quaternion.identity;

        vetGameObj[21].transform.position = new Vector3(0.5f * 3, 0.86603f * 2, -0.28868f);
        pai.transform.position = new Vector3(2f, 0.86603f * 2, 0.28868f * 2);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[21].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 37f);
        vetGameObj[21].transform.parent = null;
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


        // PARTE 2: COMPUTAR OS PLANOS QUE PASSAM PELO BARICENTRO DOS GRUPOS ===============================================

        Quaternion rotPlanoP0 = CalcularRotacaoDoPlanoAPartirDoIndiceDe3Tetraedros(1, 3, 9);
        planoTP0 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosTopoEixoP0), rotPlanoP0);
        planoMP0 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosMeioEixoP0), rotPlanoP0);
        planoBP0 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosBaseEixoP0), rotPlanoP0);

        Quaternion rotPlanoP1 = CalcularRotacaoDoPlanoAPartirDoIndiceDe3Tetraedros(1, 4, 6);
        planoTP1 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosTopoEixoP1), rotPlanoP1);
        planoMP1 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosMeioEixoP1), rotPlanoP1);
        planoBP1 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosBaseEixoP1), rotPlanoP1);

        Quaternion rotPlanoP2 = CalcularRotacaoDoPlanoAPartirDoIndiceDe3Tetraedros(6, 8, 9);
        planoTP2 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosTopoEixoP2), rotPlanoP2);
        planoMP2 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosMeioEixoP2), rotPlanoP2);
        planoBP2 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosBaseEixoP2), rotPlanoP2);

        // P3 é vertical, logo nao precisa calcular rotacao do plano
        planoTP3 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosTopoEixoP3), Quaternion.identity);
        planoMP3 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosMeioEixoP3), Quaternion.identity);
        planoBP3 = Instantiate(plano, CalcularBaricentroListaTetraedros(tetraredrosBaseEixoP3), Quaternion.identity);

        // DEIXA OS PLANOS INVISIVEIS
        planoTP0.GetComponent<Renderer>().enabled = false;
        planoMP0.GetComponent<Renderer>().enabled = false;
        planoBP0.GetComponent<Renderer>().enabled = false;

        planoTP1.GetComponent<Renderer>().enabled = false;
        planoMP1.GetComponent<Renderer>().enabled = false;
        planoBP1.GetComponent<Renderer>().enabled = false;

        planoTP2.GetComponent<Renderer>().enabled = false;
        planoMP2.GetComponent<Renderer>().enabled = false;
        planoBP2.GetComponent<Renderer>().enabled = false;

        planoTP3.GetComponent<Renderer>().enabled = false;
        planoMP3.GetComponent<Renderer>().enabled = false;
        planoBP3.GetComponent<Renderer>().enabled = false;








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
        createTetra ct = tetra.GetComponent<createTetra>();
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

    // Calcula a rotação de um plano a partir de três tetraedros.
    Quaternion CalcularRotacaoDoPlanoAPartirDoIndiceDe3Tetraedros(int i1, int i2, int i3)
    {
        Vector3 p1 = CalcularBaricentroWorld(vetGameObj[i1]);
        Vector3 p2 = CalcularBaricentroWorld(vetGameObj[i2]);
        Vector3 p3 = CalcularBaricentroWorld(vetGameObj[i3]);

        Vector3 v1 = p2 - p1;
        Vector3 v2 = p3 - p1;

        Vector3 normal = Vector3.Cross(v1, v2).normalized;

        return Quaternion.FromToRotation(Vector3.up, normal);
    }

    // Update is called once per frame
    void Update()
    {
        // ===== EIXO P0 =====
        if (Input.GetKeyDown(KeyCode.F1))
        {
            List<int> grupo = TetraedrosNoPlano(planoBP0);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP0World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosBaseEixoP0, 120f, eixoP0World);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            List<int> grupo = TetraedrosNoPlano(planoMP0);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP0World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosMeioEixoP0, 120f, eixoP0World);
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            List<int> grupo = TetraedrosNoPlano(planoTP0);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP0World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosTopoEixoP0, 120f, eixoP0World);
        }


        // ===== EIXO P1 =====
        if (Input.GetKeyDown(KeyCode.F4))
        {
            List<int> grupo = TetraedrosNoPlano(planoBP1);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP1World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosBaseEixoP1, 120f, eixoP1World);
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            List<int> grupo = TetraedrosNoPlano(planoMP1);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP1World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosMeioEixoP1, 120f, eixoP1World);
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            List<int> grupo = TetraedrosNoPlano(planoTP1);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP1World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosTopoEixoP1, 120f, eixoP1World);
        }


        // ===== EIXO P2 =====
        if (Input.GetKeyDown(KeyCode.F7))
        {
            List<int> grupo = TetraedrosNoPlano(planoBP2);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP2World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosBaseEixoP2, 120f, eixoP2World);
        }

        if (Input.GetKeyDown(KeyCode.F8))
        {
            List<int> grupo = TetraedrosNoPlano(planoMP2);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP2World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosMeioEixoP2, 120f, eixoP2World);
        }

        if (Input.GetKeyDown(KeyCode.F9))
        {
            List<int> grupo = TetraedrosNoPlano(planoTP2);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP2World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosTopoEixoP2, 120f, eixoP2World);
        }


        // ===== EIXO P3 =====

        if (Input.GetKeyDown(KeyCode.F10))
        {
            List<int> grupo = TetraedrosNoPlano(planoBP3);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP3World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosBaseEixoP3, 120f, eixoP3World);
        }

        if (Input.GetKeyDown(KeyCode.F11))
        {
            List<int> grupo = TetraedrosNoPlano(planoMP3);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP3World);
            //RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosMeioEixoP3, 120f, eixoP3World);
        }

        if (Input.GetKeyDown(KeyCode.F12))
        {
            List<int> grupo = TetraedrosNoPlano(planoTP3);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(grupo.ToArray(), 120f, eixoP3World);
            RotacionarGrupoEmTornoDoEixoQuePassaNoBaricentroDoGrupo(tetraredrosTopoEixoP3, 120f, eixoP3World);
        }
    }

    List<int> TetraedrosNoPlano(GameObject plano)
    {
        Plane plane = new Plane(plano.transform.up, plano.transform.position);

        List<int> resultado = new List<int>();

        for (int i = 0; i < vetGameObj.Length; i++)
        {
            GameObject tetra = vetGameObj[i];

            createTetra ct = tetra.GetComponent<createTetra>();
            Vector3[] verticesLocal = ct.getVectors();

            int positivos = 0;
            int negativos = 0;

            for (int j = 0; j < verticesLocal.Length; j++)
            {
                Vector3 verticeWorld = tetra.transform.TransformPoint(verticesLocal[j]);

                float distancia = plane.GetDistanceToPoint(verticeWorld);

                if (distancia > 0.001f)
                    positivos++;
                else if (distancia < -0.001f)
                    negativos++;
            }

            // Se tem vértices dos dois lados → intersecta o plano
            if (positivos > 0 && negativos > 0)
            {
                resultado.Add(i);
            }
        }

        Debug.Log("Grupo:");
        foreach (int i in resultado)
        {
            Debug.Log(i);
        }
        return resultado;
    }


}
