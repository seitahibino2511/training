using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoveText : MonoBehaviour
{
    [SerializeField] Gradient _color;
    //TextMeshProUGUI _text;
    TMP_Text _text;
    TMP_TextInfo _textInfo;
    [SerializeField] AnimationCurve _posy;
    


    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TMP_Text>();     
    }

    // Update is called once per frame
    void Update()
    {
        AnimText();
    }

    void AnimText()
    {
        // メッシュを再構成
        _text.ForceMeshUpdate(true);
        _textInfo = _text.textInfo;

        // 配列の作成
        int count = Mathf.Min(_textInfo.characterCount, _textInfo.characterInfo.Length);
        for(int i = 0; i < count; i++)
        {
            TMP_CharacterInfo charInfo = _textInfo.characterInfo[i];
            if (!charInfo.isVisible) continue;

            int materialIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;

            // Color
            Color32[] colors = _textInfo.meshInfo[materialIndex].colors32;

            float timeOffset = -0.5f * i;
            float time1 = Mathf.PingPong(timeOffset + Time.realtimeSinceStartup, 1.0f);
            float time2 = Mathf.PingPong(timeOffset + Time.realtimeSinceStartup - 0.1f, 1.0f);
            colors[vertexIndex + 0] = _color.Evaluate(time1);
            colors[vertexIndex + 1] = _color.Evaluate(time1);
            colors[vertexIndex + 2] = _color.Evaluate(time2);
            colors[vertexIndex + 3] = _color.Evaluate(time2);

            // 座標
            Vector3[] verts = _textInfo.meshInfo[materialIndex].vertices;

            float sinWaveOffset = 0.5f * i;
            float sinWave = Mathf.Sin(sinWaveOffset + Time.realtimeSinceStartup * Mathf.PI);
            verts[vertexIndex + 0].y += sinWave;
            verts[vertexIndex + 1].y += sinWave;
            verts[vertexIndex + 2].y += sinWave;
            verts[vertexIndex + 3].y += sinWave;

        }

        // メッシュの更新
        for(int i = 0; i < _textInfo.materialCount; i++)
        {
            if (_textInfo.meshInfo[i].mesh == null) continue;

            _textInfo.meshInfo[i].mesh.colors32 = _textInfo.meshInfo[i].colors32;
            _textInfo.meshInfo[i].mesh.vertices = _textInfo.meshInfo[i].vertices;
            _text.UpdateGeometry(_textInfo.meshInfo[i].mesh, i);
        }

    }
}
