using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CursorManager : MonoBehaviour {
    public static CursorManager Instance { get; private set; }
    [SerializeField] private List<CursorTexture> cursorTexturesList;
    private CursorTexture _cursorTexture;

    public enum CursorType {
        Arrow,
        Interactable,
        Reticle
    }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        SetActiveCursorType(CursorType.Reticle);
    }

    private void Update() {
        Cursor.SetCursor(_cursorTexture.texture, _cursorTexture.offset , CursorMode.Auto);
    }

    public void SetActiveCursorType(CursorType cursorType) {
        SetActiveCursorTexture(GetCursorTexture(cursorType));
    }

    private CursorTexture GetCursorTexture(CursorType cursorType) {
        return cursorTexturesList.FirstOrDefault(cursorTexture => cursorTexture.cursorType == cursorType);
    }
    
    private void SetActiveCursorTexture(CursorTexture cursorTexture) {
        _cursorTexture = cursorTexture;
    }
    
    [Serializable]
    public class CursorTexture {
        public CursorType cursorType;
        public Texture2D texture;
        public Vector2 offset;
    }
}
