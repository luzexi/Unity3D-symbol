using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DEFINE_TOOL : EditorWindow
{
    //-----------------static-----------------------
    [MenuItem("DEFINE_TOOL/TOOL")]
    public static void Open()
    {
		EditorWindow.GetWindow<DEFINE_TOOL>(true, "SMCSDefineEditor");
    }
	
    //-----------------variable-----------------------
    private DefineData[] mDefineList;
    private Vector2      mScrollView = new Vector2();
	
    private const string TEMPLETE_PATH = "Assets/smcs";


    //-----------------medhod-----------------------
    public void OnGUI()
    {
        //Init
        if(null == mDefineList) Init();

        //toggle
        mScrollView = EditorGUILayout.BeginScrollView(mScrollView);

        string tCategory = null;
		string tmpdefine = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
		string[] settingdefine = tmpdefine.Split(';');
        foreach(DefineData tDefineData in mDefineList)
		{
			//category
			if(tCategory != tDefineData.category) {
				if(null != tDefineData.category) {
					GUILayout.Label("--" + tDefineData.category + "--");
				} else {
					GUILayout.Label("---------------");
				}
				tCategory = tDefineData.category;
			}

			//flg
			tDefineData.flg = false;
			foreach( string itemdefine in settingdefine )
			{
				if(itemdefine == tDefineData.define)
				{
					tDefineData.flg = true;
					break;
				}
			}

            EditorGUILayout.BeginHorizontal();
			{
                //select
                bool nowFlg = EditorGUILayout.Toggle(tDefineData.flg, GUILayout.MaxWidth(10));
                if(nowFlg != tDefineData.flg) {
                    tDefineData.flg = nowFlg;

					string stdefine = "";
					foreach( DefineData itemdefine in mDefineList )
					{
						if(itemdefine.flg)
							stdefine +=  itemdefine.define + ";";
					}
					PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup,
					                                                 stdefine);
					//save();
					AssetDatabase.Refresh();
                }

                //define
                EditorGUILayout.SelectableLabel(tDefineData.define, GUILayout.MaxWidth(300));

                //comment
                if(null != tDefineData.comment && "" != tDefineData.comment) {
                    EditorGUILayout.TextField(tDefineData.comment);
                }
            }
			EditorGUILayout.EndHorizontal();

        }
        EditorGUILayout.EndScrollView();

		if(GUILayout.Button("ok"))
		{
			//
		}
        if(GUILayout.Button("edit template")) {
            System.Diagnostics.Process.Start("open", TEMPLETE_PATH);
        }

        if(GUILayout.Button("reload")) {
            mDefineList = null;
        }
    }



    private void Init()
    {
		if(!File.Exists(TEMPLETE_PATH))
		{
			FileStream fm = File.Create(TEMPLETE_PATH);
			fm.Close();
			AssetDatabase.Refresh();
		}
        string[] tAllLines = File.ReadAllLines(TEMPLETE_PATH);

        mDefineList  = new DefineData[tAllLines.Length];

        int tIndex = 0;
        foreach(string tLine in tAllLines) {
            string[] tSplitLine = tLine.Split(new string[]{"//"}, StringSplitOptions.None);
            mDefineList[tIndex] = new DefineData();
            mDefineList[tIndex].define = tSplitLine[0];
            if(1 < tSplitLine.Length) {
                mDefineList[tIndex].comment = tSplitLine[1];
            }
            if(2 < tSplitLine.Length) {
                mDefineList[tIndex].category = tSplitLine[2];
            }
            tIndex++;
        }


        Array.Sort<DefineData>(mDefineList, (x, y) => {
            int tRet;
            if(null != x.category && null != y.category) {
                tRet = x.category.CompareTo(y.category);
                if(0 != tRet) return tRet;
            } else if(null != x.category && null == y.category) {
                return -1;
            } else if(null == x.category && null != y.category) {
                return 1;
            }

            return -x.define.CompareTo(y.define);
        });
    }


    class DefineData
    {
        public string define;
        public string comment;
        public string category;
        public bool   flg;
    }
}

