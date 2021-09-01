using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
using UnityEngine;

public class ModLoader
{
	public void LoadModScripts(string[] fileNames)
	{
		ICodeCompiler codeCompiler = new CSharpCodeProvider().CreateCompiler();
		CompilerParameters compilerParameters = new CompilerParameters();
		foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
		{
			try
			{
				if (!compilerParameters.ReferencedAssemblies.Contains(assembly.Location) && !assembly.Location.Contains("\\Editor"))
				{
					compilerParameters.ReferencedAssemblies.Add(assembly.Location);
					Debug.Log(assembly.Location);
				}
			}
			catch
			{
			}
		}
		compilerParameters.GenerateExecutable = false;
		compilerParameters.GenerateInMemory = false;
		ModLoader.CompilerResults = codeCompiler.CompileAssemblyFromFileBatch(compilerParameters, fileNames);
		if (ModLoader.CompilerResults.Errors.HasErrors)
		{
			Debug.LogError("编译错误：");
			using (IEnumerator enumerator = ModLoader.CompilerResults.Errors.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Debug.LogError(((CompilerError)obj).ErrorText);
				}
				return;
			}
		}
		Debug.LogError(ModLoader.CompilerResults.CompiledAssembly.FullName);
		AppDomain.CurrentDomain.Load(ModLoader.CompilerResults.CompiledAssembly.FullName);
	}

	public string GenerateCode()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("using System;");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("using UnityEngine;");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("namespace DynamicCodeGenerate");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("{");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("     public class HelloWorld");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("     {");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("         public string OutPut()");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("         {");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("             return \"Hello world!\";");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("         }");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("     }");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append("}");
		string text = stringBuilder.ToString();
		Debug.Log(text);
		return text;
	}

	public static CompilerResults CompilerResults;
}
