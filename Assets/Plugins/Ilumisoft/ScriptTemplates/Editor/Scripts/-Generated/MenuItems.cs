namespace Ilumisoft.ScriptTemplates
{
	using UnityEngine;
	using UnityEditor;

	public class TemplateMenuItems : MonoBehaviour 
	{
		[MenuItem("Assets/Create/C# Script From Template/Class", priority = 81)]
		static void MenuItem0()
		{
			ScriptFactory.CreateScriptFromTemplateAsset("Assets/Plugins/Ilumisoft/ScriptTemplates/Editor/Templates/Scripts/Class.txt","Class");
		}
		
		[MenuItem("Assets/Create/C# Script From Template/Editor", priority = 81)]
		static void MenuItem1()
		{
			ScriptFactory.CreateScriptFromTemplateAsset("Assets/Plugins/Ilumisoft/ScriptTemplates/Editor/Templates/Scripts/Editor.txt","Editor");
		}
		
		[MenuItem("Assets/Create/C# Script From Template/EditorWindow", priority = 81)]
		static void MenuItem2()
		{
			ScriptFactory.CreateScriptFromTemplateAsset("Assets/Plugins/Ilumisoft/ScriptTemplates/Editor/Templates/Scripts/EditorWindow.txt","EditorWindow");
		}
		
		[MenuItem("Assets/Create/C# Script From Template/Enum", priority = 81)]
		static void MenuItem3()
		{
			ScriptFactory.CreateScriptFromTemplateAsset("Assets/Plugins/Ilumisoft/ScriptTemplates/Editor/Templates/Scripts/Enum.txt","Enum");
		}
		
		[MenuItem("Assets/Create/C# Script From Template/MonoBehaviour", priority = 81)]
		static void MenuItem4()
		{
			ScriptFactory.CreateScriptFromTemplateAsset("Assets/Plugins/Ilumisoft/ScriptTemplates/Editor/Templates/Scripts/MonoBehaviour.txt","MonoBehaviour");
		}
		
		[MenuItem("Assets/Create/C# Script From Template/ScriptableObject", priority = 81)]
		static void MenuItem5()
		{
			ScriptFactory.CreateScriptFromTemplateAsset("Assets/Plugins/Ilumisoft/ScriptTemplates/Editor/Templates/Scripts/ScriptableObject.txt","ScriptableObject");
		}
		
		[MenuItem("Assets/Create/C# Script From Template/Struct", priority = 81)]
		static void MenuItem6()
		{
			ScriptFactory.CreateScriptFromTemplateAsset("Assets/Plugins/Ilumisoft/ScriptTemplates/Editor/Templates/Scripts/Struct.txt","Struct");
		}

	}
}