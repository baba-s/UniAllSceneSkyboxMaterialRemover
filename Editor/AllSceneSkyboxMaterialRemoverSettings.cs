using System.Collections.Generic;
using UnityEngine;

namespace Kogane.Internal
{
	/// <summary>
	/// 設定を管理するクラス
	/// </summary>
	internal sealed class AllSceneSkyboxMaterialRemoverSettings : ScriptableObject
	{
		//================================================================================
		// 定数
		//================================================================================
		private const string PATH = "ProjectSettings/UniAllSceneSkyboxMaterialRemoverSettings.json";

		//================================================================================
		// 変数(SerializeField)
		//================================================================================
		[SerializeField] private string[] m_scenePathFilter = new string[0];

		//================================================================================
		// 変数(static)
		//================================================================================
		private static AllSceneSkyboxMaterialRemoverSettings m_instance;

		//================================================================================
		// プロパティ
		//================================================================================
		internal IReadOnlyList<string> ScenePathFilter => m_scenePathFilter;

		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// 設定を ProjectSettings フォルダから読み込みます
		/// </summary>
		internal static AllSceneSkyboxMaterialRemoverSettings Load()
		{
			return m_instance = ScriptableObjectToJsonFileConverter.Load( PATH, m_instance );
		}

		/// <summary>
		/// 設定を ProjectSettings フォルダに保存します
		/// </summary>
		internal static void Save()
		{
			ScriptableObjectToJsonFileConverter.Save( PATH, m_instance );
		}
	}
}