using UnityEditor;
using UnityEngine;

public class SolidWizard : ScriptableWizard 
{
	[MenuItem("Assets/Create/Solid")]
	private static void CreateWizard () 
	{
		ScriptableWizard.DisplayWizard<SolidWizard>("Create Solid");
	}

	private void OnWizardCreate () 
	{
		string path = EditorUtility.SaveFilePanelInProject(
			"Save Solid", 
			"Solid", 
			"asset", 
			"Specify where to save the mesh.");

		if (path.Length > 0) {
			Mesh mesh = SolidMeshCreator.Create();
			MeshUtility.Optimize(mesh);
			AssetDatabase.CreateAsset(mesh, path);
			Selection.activeObject = mesh;
		}
	}
}