using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kogane.Internal
{
	internal static class AllSceneSkyboxMaterialRemover
	{
		private const string MENU_ITEM_ROOT = "Edit/UniAllSceneSkyboxMaterialRemover/";

		private static readonly EditorDialog m_editorDialog = new EditorDialog( "UniAllSceneSkyboxMaterialRemover" );

		[MenuItem( MENU_ITEM_ROOT + "すべてのシーンの Skybox Material を null にする" )]
		private static void ExecuteAll()
		{
			if ( !m_editorDialog.OpenYesNo( "すべてのシーンの Skybox Material を null にしますか？" ) ) return;

			SceneProcessor.ProcessAllScenes( OnProcess );

			m_editorDialog.OpenOk( "すべてのシーンの Skybox Material を null にしました" );
		}

		[MenuItem( MENU_ITEM_ROOT + "Project Settings で設定されているシーンの Skybox Material を null にする" )]
		private static void ExecuteBy()
		{
			if ( !m_editorDialog.OpenYesNo( "Project Settings で設定されているシーンの Skybox Material を null にしますか？" ) ) return;

			var settings = AllSceneSkyboxMaterialRemoverSettings.Load();

			SceneProcessor.ProcessAllScenes
			(
				scenePathFilter: scenePath => settings.ScenePathFilter.Any( x => scenePath.StartsWith( x ) ),
				onProcess: OnProcess
			);

			m_editorDialog.OpenOk( "Project Settings で設定されているシーンの Skybox Material を null にしました" );
		}

		private static SceneProcessResult OnProcess( Scene scene )
		{
			if ( RenderSettings.skybox == null ) return SceneProcessResult.NOT_CHANGE;
			RenderSettings.skybox = null;
			return SceneProcessResult.CHANGE;
		}
	}
}