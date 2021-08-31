using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Tutorial;
using UnityEngine;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLua_Gen_Initer_Register__
	{
		private static void wrapInit0(LuaEnv luaenv, ObjectTranslator translator)
		{
			translator.DelayWrapLoader(typeof(GameObject), new Action<IntPtr>(UnityEngineGameObjectWrap.__Register));
			translator.DelayWrapLoader(typeof(GameController), new Action<IntPtr>(GameControllerWrap.__Register));
			translator.DelayWrapLoader(typeof(CardSlotData), new Action<IntPtr>(CardSlotDataWrap.__Register));
			translator.DelayWrapLoader(typeof(CardData), new Action<IntPtr>(CardDataWrap.__Register));
			translator.DelayWrapLoader(typeof(AutoPlay), new Action<IntPtr>(DGTweeningAutoPlayWrap.__Register));
			translator.DelayWrapLoader(typeof(AxisConstraint), new Action<IntPtr>(DGTweeningAxisConstraintWrap.__Register));
			translator.DelayWrapLoader(typeof(Ease), new Action<IntPtr>(DGTweeningEaseWrap.__Register));
			translator.DelayWrapLoader(typeof(LogBehaviour), new Action<IntPtr>(DGTweeningLogBehaviourWrap.__Register));
			translator.DelayWrapLoader(typeof(LoopType), new Action<IntPtr>(DGTweeningLoopTypeWrap.__Register));
			translator.DelayWrapLoader(typeof(PathMode), new Action<IntPtr>(DGTweeningPathModeWrap.__Register));
			translator.DelayWrapLoader(typeof(PathType), new Action<IntPtr>(DGTweeningPathTypeWrap.__Register));
			translator.DelayWrapLoader(typeof(RotateMode), new Action<IntPtr>(DGTweeningRotateModeWrap.__Register));
			translator.DelayWrapLoader(typeof(ScrambleMode), new Action<IntPtr>(DGTweeningScrambleModeWrap.__Register));
			translator.DelayWrapLoader(typeof(TweenType), new Action<IntPtr>(DGTweeningTweenTypeWrap.__Register));
			translator.DelayWrapLoader(typeof(UpdateType), new Action<IntPtr>(DGTweeningUpdateTypeWrap.__Register));
			translator.DelayWrapLoader(typeof(DOTween), new Action<IntPtr>(DGTweeningDOTweenWrap.__Register));
			translator.DelayWrapLoader(typeof(DOVirtual), new Action<IntPtr>(DGTweeningDOVirtualWrap.__Register));
			translator.DelayWrapLoader(typeof(EaseFactory), new Action<IntPtr>(DGTweeningEaseFactoryWrap.__Register));
			translator.DelayWrapLoader(typeof(Tweener), new Action<IntPtr>(DGTweeningTweenerWrap.__Register));
			translator.DelayWrapLoader(typeof(Tween), new Action<IntPtr>(DGTweeningTweenWrap.__Register));
			translator.DelayWrapLoader(typeof(Sequence), new Action<IntPtr>(DGTweeningSequenceWrap.__Register));
			translator.DelayWrapLoader(typeof(TweenParams), new Action<IntPtr>(DGTweeningTweenParamsWrap.__Register));
			translator.DelayWrapLoader(typeof(ABSSequentiable), new Action<IntPtr>(DGTweeningCoreABSSequentiableWrap.__Register));
			translator.DelayWrapLoader(typeof(TweenerCore<Vector3, Vector3, VectorOptions>), new Action<IntPtr>(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap.__Register));
			translator.DelayWrapLoader(typeof(TweenExtensions), new Action<IntPtr>(DGTweeningTweenExtensionsWrap.__Register));
			translator.DelayWrapLoader(typeof(TweenSettingsExtensions), new Action<IntPtr>(DGTweeningTweenSettingsExtensionsWrap.__Register));
			translator.DelayWrapLoader(typeof(ShortcutExtensions), new Action<IntPtr>(DGTweeningShortcutExtensionsWrap.__Register));
			translator.DelayWrapLoader(typeof(object), new Action<IntPtr>(SystemObjectWrap.__Register));
			translator.DelayWrapLoader(typeof(UnityEngine.Object), new Action<IntPtr>(UnityEngineObjectWrap.__Register));
			translator.DelayWrapLoader(typeof(Vector2), new Action<IntPtr>(UnityEngineVector2Wrap.__Register));
			translator.DelayWrapLoader(typeof(Vector3), new Action<IntPtr>(UnityEngineVector3Wrap.__Register));
			translator.DelayWrapLoader(typeof(Vector4), new Action<IntPtr>(UnityEngineVector4Wrap.__Register));
			translator.DelayWrapLoader(typeof(Quaternion), new Action<IntPtr>(UnityEngineQuaternionWrap.__Register));
			translator.DelayWrapLoader(typeof(Color), new Action<IntPtr>(UnityEngineColorWrap.__Register));
			translator.DelayWrapLoader(typeof(Ray), new Action<IntPtr>(UnityEngineRayWrap.__Register));
			translator.DelayWrapLoader(typeof(Bounds), new Action<IntPtr>(UnityEngineBoundsWrap.__Register));
			translator.DelayWrapLoader(typeof(Ray2D), new Action<IntPtr>(UnityEngineRay2DWrap.__Register));
			translator.DelayWrapLoader(typeof(Time), new Action<IntPtr>(UnityEngineTimeWrap.__Register));
			translator.DelayWrapLoader(typeof(Component), new Action<IntPtr>(UnityEngineComponentWrap.__Register));
			translator.DelayWrapLoader(typeof(Behaviour), new Action<IntPtr>(UnityEngineBehaviourWrap.__Register));
			translator.DelayWrapLoader(typeof(Transform), new Action<IntPtr>(UnityEngineTransformWrap.__Register));
			translator.DelayWrapLoader(typeof(Resources), new Action<IntPtr>(UnityEngineResourcesWrap.__Register));
			translator.DelayWrapLoader(typeof(TextAsset), new Action<IntPtr>(UnityEngineTextAssetWrap.__Register));
			translator.DelayWrapLoader(typeof(Keyframe), new Action<IntPtr>(UnityEngineKeyframeWrap.__Register));
			translator.DelayWrapLoader(typeof(AnimationCurve), new Action<IntPtr>(UnityEngineAnimationCurveWrap.__Register));
			translator.DelayWrapLoader(typeof(AnimationClip), new Action<IntPtr>(UnityEngineAnimationClipWrap.__Register));
			translator.DelayWrapLoader(typeof(MonoBehaviour), new Action<IntPtr>(UnityEngineMonoBehaviourWrap.__Register));
			translator.DelayWrapLoader(typeof(ParticleSystem), new Action<IntPtr>(UnityEngineParticleSystemWrap.__Register));
			translator.DelayWrapLoader(typeof(SkinnedMeshRenderer), new Action<IntPtr>(UnityEngineSkinnedMeshRendererWrap.__Register));
			translator.DelayWrapLoader(typeof(Renderer), new Action<IntPtr>(UnityEngineRendererWrap.__Register));
			translator.DelayWrapLoader(typeof(Mathf), new Action<IntPtr>(UnityEngineMathfWrap.__Register));
		}

		private static void wrapInit1(LuaEnv luaenv, ObjectTranslator translator)
		{
			translator.DelayWrapLoader(typeof(List<int>), new Action<IntPtr>(SystemCollectionsGenericList_1_SystemInt32_Wrap.__Register));
			translator.DelayWrapLoader(typeof(Debug), new Action<IntPtr>(UnityEngineDebugWrap.__Register));
			translator.DelayWrapLoader(typeof(BaseClass), new Action<IntPtr>(TutorialBaseClassWrap.__Register));
			translator.DelayWrapLoader(typeof(TestEnum), new Action<IntPtr>(TutorialTestEnumWrap.__Register));
			translator.DelayWrapLoader(typeof(DerivedClass), new Action<IntPtr>(TutorialDerivedClassWrap.__Register));
			translator.DelayWrapLoader(typeof(ICalc), new Action<IntPtr>(TutorialICalcWrap.__Register));
			translator.DelayWrapLoader(typeof(DerivedClassExtensions), new Action<IntPtr>(TutorialDerivedClassExtensionsWrap.__Register));
			translator.DelayWrapLoader(typeof(LuaBehaviour), new Action<IntPtr>(XLuaTestLuaBehaviourWrap.__Register));
			translator.DelayWrapLoader(typeof(Pedding), new Action<IntPtr>(XLuaTestPeddingWrap.__Register));
			translator.DelayWrapLoader(typeof(MyStruct), new Action<IntPtr>(XLuaTestMyStructWrap.__Register));
			translator.DelayWrapLoader(typeof(MyEnum), new Action<IntPtr>(XLuaTestMyEnumWrap.__Register));
			translator.DelayWrapLoader(typeof(NoGc), new Action<IntPtr>(XLuaTestNoGcWrap.__Register));
			translator.DelayWrapLoader(typeof(WaitForSeconds), new Action<IntPtr>(UnityEngineWaitForSecondsWrap.__Register));
			translator.DelayWrapLoader(typeof(BaseTest), new Action<IntPtr>(XLuaTestBaseTestWrap.__Register));
			translator.DelayWrapLoader(typeof(Foo1Parent), new Action<IntPtr>(XLuaTestFoo1ParentWrap.__Register));
			translator.DelayWrapLoader(typeof(Foo2Parent), new Action<IntPtr>(XLuaTestFoo2ParentWrap.__Register));
			translator.DelayWrapLoader(typeof(Foo1Child), new Action<IntPtr>(XLuaTestFoo1ChildWrap.__Register));
			translator.DelayWrapLoader(typeof(Foo2Child), new Action<IntPtr>(XLuaTestFoo2ChildWrap.__Register));
			translator.DelayWrapLoader(typeof(Foo), new Action<IntPtr>(XLuaTestFooWrap.__Register));
			translator.DelayWrapLoader(typeof(FooExtension), new Action<IntPtr>(XLuaTestFooExtensionWrap.__Register));
			translator.DelayWrapLoader(typeof(DerivedClass.TestEnumInner), new Action<IntPtr>(TutorialDerivedClassTestEnumInnerWrap.__Register));
		}

		private static void Init(LuaEnv luaenv, ObjectTranslator translator)
		{
			XLua_Gen_Initer_Register__.wrapInit0(luaenv, translator);
			XLua_Gen_Initer_Register__.wrapInit1(luaenv, translator);
			translator.AddInterfaceBridgeCreator(typeof(ICardLogic), new Func<int, LuaEnv, LuaBase>(ICardLogicBridge.__Create));
			translator.AddInterfaceBridgeCreator(typeof(IEnumerator), new Func<int, LuaEnv, LuaBase>(SystemCollectionsIEnumeratorBridge.__Create));
			translator.AddInterfaceBridgeCreator(typeof(IExchanger), new Func<int, LuaEnv, LuaBase>(XLuaTestIExchangerBridge.__Create));
			translator.AddInterfaceBridgeCreator(typeof(CSCallLua.ItfD), new Func<int, LuaEnv, LuaBase>(TutorialCSCallLuaItfDBridge.__Create));
			translator.AddInterfaceBridgeCreator(typeof(InvokeLua.ICalc), new Func<int, LuaEnv, LuaBase>(XLuaTestInvokeLuaICalcBridge.__Create));
		}

		static XLua_Gen_Initer_Register__()
		{
			LuaEnv.AddIniter(new Action<LuaEnv, ObjectTranslator>(XLua_Gen_Initer_Register__.Init));
		}
	}
}
