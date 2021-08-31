using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DeepCopyExtensions
{
	public static class DeepCopyByExpressionTrees
	{
		public static T DeepCopyByExpressionTree<T>(this T original, Dictionary<object, object> copiedReferencesDict = null)
		{
			return (T)((object)DeepCopyByExpressionTrees.DeepCopyByExpressionTreeObj(original, false, copiedReferencesDict ?? new Dictionary<object, object>(new DeepCopyByExpressionTrees.ReferenceEqualityComparer())));
		}

		private static object DeepCopyByExpressionTreeObj(object original, bool forceDeepCopy, Dictionary<object, object> copiedReferencesDict)
		{
			if (original == null)
			{
				return null;
			}
			Type type = original.GetType();
			if (DeepCopyByExpressionTrees.IsDelegate(type))
			{
				return null;
			}
			if (!forceDeepCopy && !DeepCopyByExpressionTrees.IsTypeToDeepCopy(type))
			{
				return original;
			}
			object result;
			if (copiedReferencesDict.TryGetValue(original, out result))
			{
				return result;
			}
			if (type == DeepCopyByExpressionTrees.ObjectType)
			{
				return new object();
			}
			return DeepCopyByExpressionTrees.GetOrCreateCompiledLambdaCopyFunction(type)(original, copiedReferencesDict);
		}

		private static Func<object, Dictionary<object, object>, object> GetOrCreateCompiledLambdaCopyFunction(Type type)
		{
			Func<object, Dictionary<object, object>, object> func;
			if (!DeepCopyByExpressionTrees.CompiledCopyFunctionsDictionary.TryGetValue(type, out func))
			{
				object compiledCopyFunctionsDictionaryLocker = DeepCopyByExpressionTrees.CompiledCopyFunctionsDictionaryLocker;
				lock (compiledCopyFunctionsDictionaryLocker)
				{
					if (!DeepCopyByExpressionTrees.CompiledCopyFunctionsDictionary.TryGetValue(type, out func))
					{
						func = DeepCopyByExpressionTrees.CreateCompiledLambdaCopyFunctionForType(type).Compile();
						Dictionary<Type, Func<object, Dictionary<object, object>, object>> dictionary = DeepCopyByExpressionTrees.CompiledCopyFunctionsDictionary.ToDictionary((KeyValuePair<Type, Func<object, Dictionary<object, object>, object>> pair) => pair.Key, (KeyValuePair<Type, Func<object, Dictionary<object, object>, object>> pair) => pair.Value);
						dictionary.Add(type, func);
						DeepCopyByExpressionTrees.CompiledCopyFunctionsDictionary = dictionary;
					}
				}
			}
			return func;
		}

		private static Expression<Func<object, Dictionary<object, object>, object>> CreateCompiledLambdaCopyFunctionForType(Type type)
		{
			ParameterExpression inputParameter;
			ParameterExpression inputDictionary;
			ParameterExpression outputVariable;
			ParameterExpression boxingVariable;
			LabelTarget endLabel;
			List<ParameterExpression> variables;
			List<Expression> expressions;
			DeepCopyByExpressionTrees.InitializeExpressions(type, out inputParameter, out inputDictionary, out outputVariable, out boxingVariable, out endLabel, out variables, out expressions);
			DeepCopyByExpressionTrees.IfNullThenReturnNullExpression(inputParameter, endLabel, expressions);
			DeepCopyByExpressionTrees.MemberwiseCloneInputToOutputExpression(type, inputParameter, outputVariable, expressions);
			if (DeepCopyByExpressionTrees.IsClassOtherThanString(type))
			{
				DeepCopyByExpressionTrees.StoreReferencesIntoDictionaryExpression(inputParameter, inputDictionary, outputVariable, expressions);
			}
			DeepCopyByExpressionTrees.FieldsCopyExpressions(type, inputParameter, inputDictionary, outputVariable, boxingVariable, expressions);
			if (DeepCopyByExpressionTrees.IsArray(type) && DeepCopyByExpressionTrees.IsTypeToDeepCopy(type.GetElementType()))
			{
				DeepCopyByExpressionTrees.CreateArrayCopyLoopExpression(type, inputParameter, inputDictionary, outputVariable, variables, expressions);
			}
			return DeepCopyByExpressionTrees.CombineAllIntoLambdaFunctionExpression(inputParameter, inputDictionary, outputVariable, endLabel, variables, expressions);
		}

		private static void InitializeExpressions(Type type, out ParameterExpression inputParameter, out ParameterExpression inputDictionary, out ParameterExpression outputVariable, out ParameterExpression boxingVariable, out LabelTarget endLabel, out List<ParameterExpression> variables, out List<Expression> expressions)
		{
			inputParameter = Expression.Parameter(DeepCopyByExpressionTrees.ObjectType);
			inputDictionary = Expression.Parameter(DeepCopyByExpressionTrees.ObjectDictionaryType);
			outputVariable = Expression.Variable(type);
			boxingVariable = Expression.Variable(DeepCopyByExpressionTrees.ObjectType);
			endLabel = Expression.Label();
			variables = new List<ParameterExpression>();
			expressions = new List<Expression>();
			variables.Add(outputVariable);
			variables.Add(boxingVariable);
		}

		private static void IfNullThenReturnNullExpression(ParameterExpression inputParameter, LabelTarget endLabel, List<Expression> expressions)
		{
			ConditionalExpression item = Expression.IfThen(Expression.Equal(inputParameter, Expression.Constant(null, DeepCopyByExpressionTrees.ObjectType)), Expression.Return(endLabel));
			expressions.Add(item);
		}

		private static void MemberwiseCloneInputToOutputExpression(Type type, ParameterExpression inputParameter, ParameterExpression outputVariable, List<Expression> expressions)
		{
			MethodInfo method = DeepCopyByExpressionTrees.ObjectType.GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
			BinaryExpression item = Expression.Assign(outputVariable, Expression.Convert(Expression.Call(inputParameter, method), type));
			expressions.Add(item);
		}

		private static void StoreReferencesIntoDictionaryExpression(ParameterExpression inputParameter, ParameterExpression inputDictionary, ParameterExpression outputVariable, List<Expression> expressions)
		{
			BinaryExpression item = Expression.Assign(Expression.Property(inputDictionary, DeepCopyByExpressionTrees.ObjectDictionaryType.GetProperty("Item"), new Expression[]
			{
				inputParameter
			}), Expression.Convert(outputVariable, DeepCopyByExpressionTrees.ObjectType));
			expressions.Add(item);
		}

		private static Expression<Func<object, Dictionary<object, object>, object>> CombineAllIntoLambdaFunctionExpression(ParameterExpression inputParameter, ParameterExpression inputDictionary, ParameterExpression outputVariable, LabelTarget endLabel, List<ParameterExpression> variables, List<Expression> expressions)
		{
			expressions.Add(Expression.Label(endLabel));
			expressions.Add(Expression.Convert(outputVariable, DeepCopyByExpressionTrees.ObjectType));
			return Expression.Lambda<Func<object, Dictionary<object, object>, object>>(Expression.Block(variables, expressions), new ParameterExpression[]
			{
				inputParameter,
				inputDictionary
			});
		}

		private static void CreateArrayCopyLoopExpression(Type type, ParameterExpression inputParameter, ParameterExpression inputDictionary, ParameterExpression outputVariable, List<ParameterExpression> variables, List<Expression> expressions)
		{
			int arrayRank = type.GetArrayRank();
			List<ParameterExpression> list = DeepCopyByExpressionTrees.GenerateIndices(arrayRank);
			variables.AddRange(list);
			Type elementType = type.GetElementType();
			Expression expression = DeepCopyByExpressionTrees.ArrayFieldToArrayFieldAssignExpression(inputParameter, inputDictionary, outputVariable, elementType, type, list);
			for (int i = 0; i < arrayRank; i++)
			{
				ParameterExpression indexVariable = list[i];
				expression = DeepCopyByExpressionTrees.LoopIntoLoopExpression(inputParameter, indexVariable, expression, i);
			}
			expressions.Add(expression);
		}

		private static List<ParameterExpression> GenerateIndices(int arrayRank)
		{
			List<ParameterExpression> list = new List<ParameterExpression>();
			for (int i = 0; i < arrayRank; i++)
			{
				ParameterExpression item = Expression.Variable(typeof(int));
				list.Add(item);
			}
			return list;
		}

		private static BinaryExpression ArrayFieldToArrayFieldAssignExpression(ParameterExpression inputParameter, ParameterExpression inputDictionary, ParameterExpression outputVariable, Type elementType, Type arrayType, List<ParameterExpression> indices)
		{
			Expression left = Expression.ArrayAccess(outputVariable, indices);
			MethodCallExpression expression = Expression.ArrayIndex(Expression.Convert(inputParameter, arrayType), indices);
			bool flag = elementType != DeepCopyByExpressionTrees.ObjectType;
			UnaryExpression right = Expression.Convert(Expression.Call(DeepCopyByExpressionTrees.DeepCopyByExpressionTreeObjMethod, Expression.Convert(expression, DeepCopyByExpressionTrees.ObjectType), Expression.Constant(flag, typeof(bool)), inputDictionary), elementType);
			return Expression.Assign(left, right);
		}

		private static BlockExpression LoopIntoLoopExpression(ParameterExpression inputParameter, ParameterExpression indexVariable, Expression loopToEncapsulate, int dimension)
		{
			ParameterExpression parameterExpression = Expression.Variable(typeof(int));
			LabelTarget labelTarget = Expression.Label();
			LoopExpression loopExpression = Expression.Loop(Expression.Block(new ParameterExpression[0], new Expression[]
			{
				Expression.IfThen(Expression.GreaterThanOrEqual(indexVariable, parameterExpression), Expression.Break(labelTarget)),
				loopToEncapsulate,
				Expression.PostIncrementAssign(indexVariable)
			}), labelTarget);
			BinaryExpression lengthForDimensionExpression = DeepCopyByExpressionTrees.GetLengthForDimensionExpression(parameterExpression, inputParameter, dimension);
			BinaryExpression binaryExpression = Expression.Assign(indexVariable, Expression.Constant(0));
			return Expression.Block(new ParameterExpression[]
			{
				parameterExpression
			}, new Expression[]
			{
				lengthForDimensionExpression,
				binaryExpression,
				loopExpression
			});
		}

		private static BinaryExpression GetLengthForDimensionExpression(ParameterExpression lengthVariable, ParameterExpression inputParameter, int i)
		{
			MethodInfo method = typeof(Array).GetMethod("GetLength", BindingFlags.Instance | BindingFlags.Public);
			ConstantExpression constantExpression = Expression.Constant(i);
			Expression instance = Expression.Convert(inputParameter, typeof(Array));
			MethodInfo method2 = method;
			Expression[] arguments = new ConstantExpression[]
			{
				constantExpression
			};
			return Expression.Assign(lengthVariable, Expression.Call(instance, method2, arguments));
		}

		private static void FieldsCopyExpressions(Type type, ParameterExpression inputParameter, ParameterExpression inputDictionary, ParameterExpression outputVariable, ParameterExpression boxingVariable, List<Expression> expressions)
		{
			FieldInfo[] allRelevantFields = DeepCopyByExpressionTrees.GetAllRelevantFields(type, false);
			List<FieldInfo> list = (from f in allRelevantFields
			where f.IsInitOnly
			select f).ToList<FieldInfo>();
			List<FieldInfo> list2 = (from f in allRelevantFields
			where !f.IsInitOnly
			select f).ToList<FieldInfo>();
			bool flag = list.Any<FieldInfo>();
			if (flag)
			{
				BinaryExpression item = Expression.Assign(boxingVariable, Expression.Convert(outputVariable, DeepCopyByExpressionTrees.ObjectType));
				expressions.Add(item);
			}
			foreach (FieldInfo fieldInfo in list)
			{
				if (DeepCopyByExpressionTrees.IsDelegate(fieldInfo.FieldType))
				{
					DeepCopyByExpressionTrees.ReadonlyFieldToNullExpression(fieldInfo, boxingVariable, expressions);
				}
				else
				{
					DeepCopyByExpressionTrees.ReadonlyFieldCopyExpression(type, fieldInfo, inputParameter, inputDictionary, boxingVariable, expressions);
				}
			}
			if (flag)
			{
				BinaryExpression item2 = Expression.Assign(outputVariable, Expression.Convert(boxingVariable, type));
				expressions.Add(item2);
			}
			foreach (FieldInfo fieldInfo2 in list2)
			{
				if (DeepCopyByExpressionTrees.IsDelegate(fieldInfo2.FieldType) || DeepCopyByExpressionTrees.HasAttribute(fieldInfo2, typeof(NonSerializedAttribute)))
				{
					DeepCopyByExpressionTrees.WritableFieldToNullExpression(fieldInfo2, outputVariable, expressions);
				}
				else
				{
					DeepCopyByExpressionTrees.WritableFieldCopyExpression(type, fieldInfo2, inputParameter, inputDictionary, outputVariable, expressions);
				}
			}
		}

		private static FieldInfo[] GetAllRelevantFields(Type type, bool forceAllFields = false)
		{
			List<FieldInfo> list = new List<FieldInfo>();
			Type type2 = type;
			while (type2 != null)
			{
				list.AddRange(from field in type2.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy)
				where forceAllFields || DeepCopyByExpressionTrees.IsTypeToDeepCopy(field.FieldType)
				select field);
				type2 = type2.BaseType;
			}
			return list.ToArray();
		}

		public static bool HasAttribute(FieldInfo fieldInfo, Type attribute)
		{
			return fieldInfo.GetCustomAttribute(attribute) != null;
		}

		private static FieldInfo[] GetAllFields(Type type)
		{
			return DeepCopyByExpressionTrees.GetAllRelevantFields(type, true);
		}

		private static void ReadonlyFieldToNullExpression(FieldInfo field, ParameterExpression boxingVariable, List<Expression> expressions)
		{
			MethodCallExpression item = Expression.Call(Expression.Constant(field), DeepCopyByExpressionTrees.SetValueMethod, boxingVariable, Expression.Constant(null, field.FieldType));
			expressions.Add(item);
		}

		private static void ReadonlyFieldCopyExpression(Type type, FieldInfo field, ParameterExpression inputParameter, ParameterExpression inputDictionary, ParameterExpression boxingVariable, List<Expression> expressions)
		{
			MemberExpression expression = Expression.Field(Expression.Convert(inputParameter, type), field);
			bool flag = field.FieldType != DeepCopyByExpressionTrees.ObjectType;
			MethodCallExpression item = Expression.Call(Expression.Constant(field, DeepCopyByExpressionTrees.FieldInfoType), DeepCopyByExpressionTrees.SetValueMethod, boxingVariable, Expression.Call(DeepCopyByExpressionTrees.DeepCopyByExpressionTreeObjMethod, Expression.Convert(expression, DeepCopyByExpressionTrees.ObjectType), Expression.Constant(flag, typeof(bool)), inputDictionary));
			expressions.Add(item);
		}

		private static void WritableFieldToNullExpression(FieldInfo field, ParameterExpression outputVariable, List<Expression> expressions)
		{
			BinaryExpression item = Expression.Assign(Expression.Field(outputVariable, field), Expression.Constant(null, field.FieldType));
			expressions.Add(item);
		}

		private static void WritableFieldCopyExpression(Type type, FieldInfo field, ParameterExpression inputParameter, ParameterExpression inputDictionary, ParameterExpression outputVariable, List<Expression> expressions)
		{
			MemberExpression expression = Expression.Field(Expression.Convert(inputParameter, type), field);
			Type fieldType = field.FieldType;
			Expression left = Expression.Field(outputVariable, field);
			bool flag = field.FieldType != DeepCopyByExpressionTrees.ObjectType;
			BinaryExpression item = Expression.Assign(left, Expression.Convert(Expression.Call(DeepCopyByExpressionTrees.DeepCopyByExpressionTreeObjMethod, Expression.Convert(expression, DeepCopyByExpressionTrees.ObjectType), Expression.Constant(flag, typeof(bool)), inputDictionary), fieldType));
			expressions.Add(item);
		}

		private static bool IsArray(Type type)
		{
			return type.IsArray;
		}

		private static bool IsDelegate(Type type)
		{
			return typeof(Delegate).IsAssignableFrom(type);
		}

		private static bool IsTypeToDeepCopy(Type type)
		{
			return DeepCopyByExpressionTrees.IsClassOtherThanString(type) || DeepCopyByExpressionTrees.IsStructWhichNeedsDeepCopy(type);
		}

		private static bool IsClassOtherThanString(Type type)
		{
			return !type.IsValueType && type != typeof(string);
		}

		private static bool IsStructWhichNeedsDeepCopy(Type type)
		{
			bool flag;
			if (!DeepCopyByExpressionTrees.IsStructTypeToDeepCopyDictionary.TryGetValue(type, out flag))
			{
				object isStructTypeToDeepCopyDictionaryLocker = DeepCopyByExpressionTrees.IsStructTypeToDeepCopyDictionaryLocker;
				lock (isStructTypeToDeepCopyDictionaryLocker)
				{
					if (!DeepCopyByExpressionTrees.IsStructTypeToDeepCopyDictionary.TryGetValue(type, out flag))
					{
						flag = DeepCopyByExpressionTrees.IsStructWhichNeedsDeepCopy_NoDictionaryUsed(type);
						Dictionary<Type, bool> dictionary = DeepCopyByExpressionTrees.IsStructTypeToDeepCopyDictionary.ToDictionary((KeyValuePair<Type, bool> pair) => pair.Key, (KeyValuePair<Type, bool> pair) => pair.Value);
						dictionary[type] = flag;
						DeepCopyByExpressionTrees.IsStructTypeToDeepCopyDictionary = dictionary;
					}
				}
			}
			return flag;
		}

		private static bool IsStructWhichNeedsDeepCopy_NoDictionaryUsed(Type type)
		{
			return DeepCopyByExpressionTrees.IsStructOtherThanBasicValueTypes(type) && DeepCopyByExpressionTrees.HasInItsHierarchyFieldsWithClasses(type, null);
		}

		private static bool IsStructOtherThanBasicValueTypes(Type type)
		{
			return type.IsValueType && !type.IsPrimitive && !type.IsEnum && type != typeof(decimal);
		}

		private static bool HasInItsHierarchyFieldsWithClasses(Type type, HashSet<Type> alreadyCheckedTypes = null)
		{
			alreadyCheckedTypes = (alreadyCheckedTypes ?? new HashSet<Type>());
			alreadyCheckedTypes.Add(type);
			List<Type> source = (from f in DeepCopyByExpressionTrees.GetAllFields(type)
			select f.FieldType).Distinct<Type>().ToList<Type>();
			if (source.Any(new Func<Type, bool>(DeepCopyByExpressionTrees.IsClassOtherThanString)))
			{
				return true;
			}
			using (List<Type>.Enumerator enumerator = (from t in source.Where(new Func<Type, bool>(DeepCopyByExpressionTrees.IsStructOtherThanBasicValueTypes)).ToList<Type>()
			where !alreadyCheckedTypes.Contains(t)
			select t).ToList<Type>().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (DeepCopyByExpressionTrees.HasInItsHierarchyFieldsWithClasses(enumerator.Current, alreadyCheckedTypes))
					{
						return true;
					}
				}
			}
			return false;
		}

		private static readonly object IsStructTypeToDeepCopyDictionaryLocker = new object();

		private static Dictionary<Type, bool> IsStructTypeToDeepCopyDictionary = new Dictionary<Type, bool>();

		private static readonly object CompiledCopyFunctionsDictionaryLocker = new object();

		private static Dictionary<Type, Func<object, Dictionary<object, object>, object>> CompiledCopyFunctionsDictionary = new Dictionary<Type, Func<object, Dictionary<object, object>, object>>();

		private static readonly Type ObjectType = typeof(object);

		private static readonly Type ObjectDictionaryType = typeof(Dictionary<object, object>);

		private static readonly Type FieldInfoType = typeof(FieldInfo);

		private static readonly MethodInfo SetValueMethod = DeepCopyByExpressionTrees.FieldInfoType.GetMethod("SetValue", new Type[]
		{
			DeepCopyByExpressionTrees.ObjectType,
			DeepCopyByExpressionTrees.ObjectType
		});

		private static readonly Type ThisType = typeof(DeepCopyByExpressionTrees);

		private static readonly MethodInfo DeepCopyByExpressionTreeObjMethod = DeepCopyByExpressionTrees.ThisType.GetMethod("DeepCopyByExpressionTreeObj", BindingFlags.Static | BindingFlags.NonPublic);

		public class ReferenceEqualityComparer : EqualityComparer<object>
		{
			public override bool Equals(object x, object y)
			{
				return x == y;
			}

			public override int GetHashCode(object obj)
			{
				if (obj == null)
				{
					return 0;
				}
				return obj.GetHashCode();
			}
		}
	}
}
