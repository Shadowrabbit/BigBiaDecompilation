using System;
using System.Collections.Generic;
using System.Reflection;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua
{
	internal class InternalGlobals
	{
		static InternalGlobals()
		{
			InternalGlobals.extensionMethodMap = new Dictionary<Type, IEnumerable<MethodInfo>>
			{
				{
					typeof(Tween),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE0(TweenExtensions.Complete).Method,
						new InternalGlobals.__GEN_DELEGATE1(TweenExtensions.Complete).Method,
						new InternalGlobals.__GEN_DELEGATE2(TweenExtensions.Flip).Method,
						new InternalGlobals.__GEN_DELEGATE3(TweenExtensions.ForceInit).Method,
						new InternalGlobals.__GEN_DELEGATE4(TweenExtensions.Goto).Method,
						new InternalGlobals.__GEN_DELEGATE5(TweenExtensions.Kill).Method,
						new InternalGlobals.__GEN_DELEGATE6(TweenExtensions.Pause<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE7(TweenExtensions.Play<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE8(TweenExtensions.PlayBackwards).Method,
						new InternalGlobals.__GEN_DELEGATE9(TweenExtensions.PlayForward).Method,
						new InternalGlobals.__GEN_DELEGATE10(TweenExtensions.Restart).Method,
						new InternalGlobals.__GEN_DELEGATE11(TweenExtensions.Rewind).Method,
						new InternalGlobals.__GEN_DELEGATE12(TweenExtensions.SmoothRewind).Method,
						new InternalGlobals.__GEN_DELEGATE13(TweenExtensions.TogglePause).Method,
						new InternalGlobals.__GEN_DELEGATE14(TweenExtensions.GotoWaypoint).Method,
						new InternalGlobals.__GEN_DELEGATE15(TweenExtensions.WaitForCompletion).Method,
						new InternalGlobals.__GEN_DELEGATE16(TweenExtensions.WaitForRewind).Method,
						new InternalGlobals.__GEN_DELEGATE17(TweenExtensions.WaitForKill).Method,
						new InternalGlobals.__GEN_DELEGATE18(TweenExtensions.WaitForElapsedLoops).Method,
						new InternalGlobals.__GEN_DELEGATE19(TweenExtensions.WaitForPosition).Method,
						new InternalGlobals.__GEN_DELEGATE20(TweenExtensions.WaitForStart).Method,
						new InternalGlobals.__GEN_DELEGATE21(TweenExtensions.CompletedLoops).Method,
						new InternalGlobals.__GEN_DELEGATE22(TweenExtensions.Delay).Method,
						new InternalGlobals.__GEN_DELEGATE23(TweenExtensions.Duration).Method,
						new InternalGlobals.__GEN_DELEGATE24(TweenExtensions.Elapsed).Method,
						new InternalGlobals.__GEN_DELEGATE25(TweenExtensions.ElapsedPercentage).Method,
						new InternalGlobals.__GEN_DELEGATE26(TweenExtensions.ElapsedDirectionalPercentage).Method,
						new InternalGlobals.__GEN_DELEGATE27(TweenExtensions.IsActive).Method,
						new InternalGlobals.__GEN_DELEGATE28(TweenExtensions.IsBackwards).Method,
						new InternalGlobals.__GEN_DELEGATE29(TweenExtensions.IsComplete).Method,
						new InternalGlobals.__GEN_DELEGATE30(TweenExtensions.IsInitialized).Method,
						new InternalGlobals.__GEN_DELEGATE31(TweenExtensions.IsPlaying).Method,
						new InternalGlobals.__GEN_DELEGATE32(TweenExtensions.Loops).Method,
						new InternalGlobals.__GEN_DELEGATE33(TweenExtensions.PathGetPoint).Method,
						new InternalGlobals.__GEN_DELEGATE34(TweenExtensions.PathGetDrawPoints).Method,
						new InternalGlobals.__GEN_DELEGATE35(TweenExtensions.PathLength).Method,
						new InternalGlobals.__GEN_DELEGATE36(TweenSettingsExtensions.SetAutoKill<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE37(TweenSettingsExtensions.SetAutoKill<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE38(TweenSettingsExtensions.SetId<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE39(TweenSettingsExtensions.SetId<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE40(TweenSettingsExtensions.SetId<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE41(TweenSettingsExtensions.SetLink<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE42(TweenSettingsExtensions.SetLink<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE43(TweenSettingsExtensions.SetTarget<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE44(TweenSettingsExtensions.SetLoops<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE45(TweenSettingsExtensions.SetLoops<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE46(TweenSettingsExtensions.SetEase<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE47(TweenSettingsExtensions.SetEase<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE48(TweenSettingsExtensions.SetEase<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE49(TweenSettingsExtensions.SetEase<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE50(TweenSettingsExtensions.SetEase<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE51(TweenSettingsExtensions.SetRecyclable<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE52(TweenSettingsExtensions.SetRecyclable<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE53(TweenSettingsExtensions.SetUpdate<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE54(TweenSettingsExtensions.SetUpdate<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE55(TweenSettingsExtensions.SetUpdate<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE56(TweenSettingsExtensions.OnStart<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE57(TweenSettingsExtensions.OnPlay<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE58(TweenSettingsExtensions.OnPause<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE59(TweenSettingsExtensions.OnRewind<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE60(TweenSettingsExtensions.OnUpdate<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE61(TweenSettingsExtensions.OnStepComplete<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE62(TweenSettingsExtensions.OnComplete<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE63(TweenSettingsExtensions.OnKill<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE64(TweenSettingsExtensions.OnWaypointChange<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE65(TweenSettingsExtensions.SetAs<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE66(TweenSettingsExtensions.SetAs<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE80(TweenSettingsExtensions.SetDelay<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE81(TweenSettingsExtensions.SetRelative<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE82(TweenSettingsExtensions.SetRelative<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE83(TweenSettingsExtensions.SetSpeedBased<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE84(TweenSettingsExtensions.SetSpeedBased<Tween>).Method,
						new InternalGlobals.__GEN_DELEGATE168(ShortcutExtensions.DOTimeScale).Method
					}
				},
				{
					typeof(Sequence),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE67(TweenSettingsExtensions.Append).Method,
						new InternalGlobals.__GEN_DELEGATE68(TweenSettingsExtensions.Prepend).Method,
						new InternalGlobals.__GEN_DELEGATE69(TweenSettingsExtensions.Join).Method,
						new InternalGlobals.__GEN_DELEGATE70(TweenSettingsExtensions.Insert).Method,
						new InternalGlobals.__GEN_DELEGATE71(TweenSettingsExtensions.AppendInterval).Method,
						new InternalGlobals.__GEN_DELEGATE72(TweenSettingsExtensions.PrependInterval).Method,
						new InternalGlobals.__GEN_DELEGATE73(TweenSettingsExtensions.AppendCallback).Method,
						new InternalGlobals.__GEN_DELEGATE74(TweenSettingsExtensions.PrependCallback).Method,
						new InternalGlobals.__GEN_DELEGATE75(TweenSettingsExtensions.InsertCallback).Method
					}
				},
				{
					typeof(Tweener),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE76(TweenSettingsExtensions.From<Tweener>).Method,
						new InternalGlobals.__GEN_DELEGATE77(TweenSettingsExtensions.From<Tweener>).Method
					}
				},
				{
					typeof(TweenerCore<Color, Color, ColorOptions>),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE78(TweenSettingsExtensions.From).Method,
						new InternalGlobals.__GEN_DELEGATE93(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE203(TweenSettingsExtensions.From).Method,
						new InternalGlobals.__GEN_DELEGATE210(TweenSettingsExtensions.SetOptions).Method
					}
				},
				{
					typeof(TweenerCore<Vector3, Vector3, VectorOptions>),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE79(TweenSettingsExtensions.From).Method,
						new InternalGlobals.__GEN_DELEGATE88(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE89(TweenSettingsExtensions.SetOptions).Method
					}
				},
				{
					typeof(TweenerCore<float, float, FloatOptions>),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE85(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE204(TweenSettingsExtensions.SetOptions).Method
					}
				},
				{
					typeof(TweenerCore<Vector2, Vector2, VectorOptions>),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE86(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE87(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE205(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE206(TweenSettingsExtensions.SetOptions).Method
					}
				},
				{
					typeof(TweenerCore<Vector4, Vector4, VectorOptions>),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE90(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE91(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE207(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE208(TweenSettingsExtensions.SetOptions).Method
					}
				},
				{
					typeof(TweenerCore<Quaternion, Vector3, QuaternionOptions>),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE92(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE209(TweenSettingsExtensions.SetOptions).Method
					}
				},
				{
					typeof(TweenerCore<Rect, Rect, RectOptions>),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE94(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE211(TweenSettingsExtensions.SetOptions).Method
					}
				},
				{
					typeof(TweenerCore<string, string, StringOptions>),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE95(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE212(TweenSettingsExtensions.SetOptions).Method
					}
				},
				{
					typeof(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE96(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE97(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE213(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE214(TweenSettingsExtensions.SetOptions).Method
					}
				},
				{
					typeof(TweenerCore<Vector3, Path, PathOptions>),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE98(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE99(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE100(TweenSettingsExtensions.SetLookAt).Method,
						new InternalGlobals.__GEN_DELEGATE101(TweenSettingsExtensions.SetLookAt).Method,
						new InternalGlobals.__GEN_DELEGATE102(TweenSettingsExtensions.SetLookAt).Method,
						new InternalGlobals.__GEN_DELEGATE215(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE216(TweenSettingsExtensions.SetOptions).Method,
						new InternalGlobals.__GEN_DELEGATE217(TweenSettingsExtensions.SetLookAt).Method,
						new InternalGlobals.__GEN_DELEGATE218(TweenSettingsExtensions.SetLookAt).Method,
						new InternalGlobals.__GEN_DELEGATE219(TweenSettingsExtensions.SetLookAt).Method
					}
				},
				{
					typeof(Camera),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE103(ShortcutExtensions.DOAspect).Method,
						new InternalGlobals.__GEN_DELEGATE104(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE105(ShortcutExtensions.DOFarClipPlane).Method,
						new InternalGlobals.__GEN_DELEGATE106(ShortcutExtensions.DOFieldOfView).Method,
						new InternalGlobals.__GEN_DELEGATE107(ShortcutExtensions.DONearClipPlane).Method,
						new InternalGlobals.__GEN_DELEGATE108(ShortcutExtensions.DOOrthoSize).Method,
						new InternalGlobals.__GEN_DELEGATE109(ShortcutExtensions.DOPixelRect).Method,
						new InternalGlobals.__GEN_DELEGATE110(ShortcutExtensions.DORect).Method,
						new InternalGlobals.__GEN_DELEGATE111(ShortcutExtensions.DOShakePosition).Method,
						new InternalGlobals.__GEN_DELEGATE112(ShortcutExtensions.DOShakePosition).Method,
						new InternalGlobals.__GEN_DELEGATE113(ShortcutExtensions.DOShakeRotation).Method,
						new InternalGlobals.__GEN_DELEGATE114(ShortcutExtensions.DOShakeRotation).Method,
						new InternalGlobals.__GEN_DELEGATE220(ShortcutExtensions.DOAspect).Method,
						new InternalGlobals.__GEN_DELEGATE221(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE222(ShortcutExtensions.DOFarClipPlane).Method,
						new InternalGlobals.__GEN_DELEGATE223(ShortcutExtensions.DOFieldOfView).Method,
						new InternalGlobals.__GEN_DELEGATE224(ShortcutExtensions.DONearClipPlane).Method,
						new InternalGlobals.__GEN_DELEGATE225(ShortcutExtensions.DOOrthoSize).Method,
						new InternalGlobals.__GEN_DELEGATE226(ShortcutExtensions.DOPixelRect).Method,
						new InternalGlobals.__GEN_DELEGATE227(ShortcutExtensions.DORect).Method,
						new InternalGlobals.__GEN_DELEGATE228(ShortcutExtensions.DOShakePosition).Method,
						new InternalGlobals.__GEN_DELEGATE229(ShortcutExtensions.DOShakePosition).Method,
						new InternalGlobals.__GEN_DELEGATE230(ShortcutExtensions.DOShakeRotation).Method,
						new InternalGlobals.__GEN_DELEGATE231(ShortcutExtensions.DOShakeRotation).Method
					}
				},
				{
					typeof(Light),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE115(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE116(ShortcutExtensions.DOIntensity).Method,
						new InternalGlobals.__GEN_DELEGATE117(ShortcutExtensions.DOShadowStrength).Method,
						new InternalGlobals.__GEN_DELEGATE169(ShortcutExtensions.DOBlendableColor).Method,
						new InternalGlobals.__GEN_DELEGATE232(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE233(ShortcutExtensions.DOIntensity).Method,
						new InternalGlobals.__GEN_DELEGATE234(ShortcutExtensions.DOShadowStrength).Method,
						new InternalGlobals.__GEN_DELEGATE252(ShortcutExtensions.DOBlendableColor).Method
					}
				},
				{
					typeof(LineRenderer),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE118(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE235(ShortcutExtensions.DOColor).Method
					}
				},
				{
					typeof(Material),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE119(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE120(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE121(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE122(ShortcutExtensions.DOFade).Method,
						new InternalGlobals.__GEN_DELEGATE123(ShortcutExtensions.DOFade).Method,
						new InternalGlobals.__GEN_DELEGATE124(ShortcutExtensions.DOFade).Method,
						new InternalGlobals.__GEN_DELEGATE125(ShortcutExtensions.DOFloat).Method,
						new InternalGlobals.__GEN_DELEGATE126(ShortcutExtensions.DOFloat).Method,
						new InternalGlobals.__GEN_DELEGATE127(ShortcutExtensions.DOOffset).Method,
						new InternalGlobals.__GEN_DELEGATE128(ShortcutExtensions.DOOffset).Method,
						new InternalGlobals.__GEN_DELEGATE129(ShortcutExtensions.DOTiling).Method,
						new InternalGlobals.__GEN_DELEGATE130(ShortcutExtensions.DOTiling).Method,
						new InternalGlobals.__GEN_DELEGATE131(ShortcutExtensions.DOVector).Method,
						new InternalGlobals.__GEN_DELEGATE132(ShortcutExtensions.DOVector).Method,
						new InternalGlobals.__GEN_DELEGATE170(ShortcutExtensions.DOBlendableColor).Method,
						new InternalGlobals.__GEN_DELEGATE171(ShortcutExtensions.DOBlendableColor).Method,
						new InternalGlobals.__GEN_DELEGATE172(ShortcutExtensions.DOBlendableColor).Method,
						new InternalGlobals.__GEN_DELEGATE180(ShortcutExtensions.DOComplete).Method,
						new InternalGlobals.__GEN_DELEGATE182(ShortcutExtensions.DOKill).Method,
						new InternalGlobals.__GEN_DELEGATE184(ShortcutExtensions.DOFlip).Method,
						new InternalGlobals.__GEN_DELEGATE186(ShortcutExtensions.DOGoto).Method,
						new InternalGlobals.__GEN_DELEGATE188(ShortcutExtensions.DOPause).Method,
						new InternalGlobals.__GEN_DELEGATE190(ShortcutExtensions.DOPlay).Method,
						new InternalGlobals.__GEN_DELEGATE192(ShortcutExtensions.DOPlayBackwards).Method,
						new InternalGlobals.__GEN_DELEGATE194(ShortcutExtensions.DOPlayForward).Method,
						new InternalGlobals.__GEN_DELEGATE196(ShortcutExtensions.DORestart).Method,
						new InternalGlobals.__GEN_DELEGATE198(ShortcutExtensions.DORewind).Method,
						new InternalGlobals.__GEN_DELEGATE200(ShortcutExtensions.DOSmoothRewind).Method,
						new InternalGlobals.__GEN_DELEGATE202(ShortcutExtensions.DOTogglePause).Method,
						new InternalGlobals.__GEN_DELEGATE236(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE237(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE238(ShortcutExtensions.DOColor).Method,
						new InternalGlobals.__GEN_DELEGATE239(ShortcutExtensions.DOFade).Method,
						new InternalGlobals.__GEN_DELEGATE240(ShortcutExtensions.DOFade).Method,
						new InternalGlobals.__GEN_DELEGATE241(ShortcutExtensions.DOFade).Method,
						new InternalGlobals.__GEN_DELEGATE242(ShortcutExtensions.DOFloat).Method,
						new InternalGlobals.__GEN_DELEGATE243(ShortcutExtensions.DOFloat).Method,
						new InternalGlobals.__GEN_DELEGATE244(ShortcutExtensions.DOOffset).Method,
						new InternalGlobals.__GEN_DELEGATE245(ShortcutExtensions.DOOffset).Method,
						new InternalGlobals.__GEN_DELEGATE246(ShortcutExtensions.DOTiling).Method,
						new InternalGlobals.__GEN_DELEGATE247(ShortcutExtensions.DOTiling).Method,
						new InternalGlobals.__GEN_DELEGATE248(ShortcutExtensions.DOVector).Method,
						new InternalGlobals.__GEN_DELEGATE249(ShortcutExtensions.DOVector).Method,
						new InternalGlobals.__GEN_DELEGATE253(ShortcutExtensions.DOBlendableColor).Method,
						new InternalGlobals.__GEN_DELEGATE254(ShortcutExtensions.DOBlendableColor).Method,
						new InternalGlobals.__GEN_DELEGATE255(ShortcutExtensions.DOBlendableColor).Method,
						new InternalGlobals.__GEN_DELEGATE256(ShortcutExtensions.DOComplete).Method,
						new InternalGlobals.__GEN_DELEGATE257(ShortcutExtensions.DOKill).Method,
						new InternalGlobals.__GEN_DELEGATE258(ShortcutExtensions.DOFlip).Method,
						new InternalGlobals.__GEN_DELEGATE259(ShortcutExtensions.DOGoto).Method,
						new InternalGlobals.__GEN_DELEGATE260(ShortcutExtensions.DOPause).Method,
						new InternalGlobals.__GEN_DELEGATE261(ShortcutExtensions.DOPlay).Method,
						new InternalGlobals.__GEN_DELEGATE262(ShortcutExtensions.DOPlayBackwards).Method,
						new InternalGlobals.__GEN_DELEGATE263(ShortcutExtensions.DOPlayForward).Method,
						new InternalGlobals.__GEN_DELEGATE264(ShortcutExtensions.DORestart).Method,
						new InternalGlobals.__GEN_DELEGATE265(ShortcutExtensions.DORewind).Method,
						new InternalGlobals.__GEN_DELEGATE266(ShortcutExtensions.DOSmoothRewind).Method,
						new InternalGlobals.__GEN_DELEGATE267(ShortcutExtensions.DOTogglePause).Method
					}
				},
				{
					typeof(TrailRenderer),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE133(ShortcutExtensions.DOResize).Method,
						new InternalGlobals.__GEN_DELEGATE134(ShortcutExtensions.DOTime).Method,
						new InternalGlobals.__GEN_DELEGATE250(ShortcutExtensions.DOResize).Method,
						new InternalGlobals.__GEN_DELEGATE251(ShortcutExtensions.DOTime).Method
					}
				},
				{
					typeof(Transform),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE135(ShortcutExtensions.DOMove).Method,
						new InternalGlobals.__GEN_DELEGATE136(ShortcutExtensions.DOMoveX).Method,
						new InternalGlobals.__GEN_DELEGATE137(ShortcutExtensions.DOMoveY).Method,
						new InternalGlobals.__GEN_DELEGATE138(ShortcutExtensions.DOMoveZ).Method,
						new InternalGlobals.__GEN_DELEGATE139(ShortcutExtensions.DOLocalMove).Method,
						new InternalGlobals.__GEN_DELEGATE140(ShortcutExtensions.DOLocalMoveX).Method,
						new InternalGlobals.__GEN_DELEGATE141(ShortcutExtensions.DOLocalMoveY).Method,
						new InternalGlobals.__GEN_DELEGATE142(ShortcutExtensions.DOLocalMoveZ).Method,
						new InternalGlobals.__GEN_DELEGATE143(ShortcutExtensions.DORotate).Method,
						new InternalGlobals.__GEN_DELEGATE144(ShortcutExtensions.DORotateQuaternion).Method,
						new InternalGlobals.__GEN_DELEGATE145(ShortcutExtensions.DOLocalRotate).Method,
						new InternalGlobals.__GEN_DELEGATE146(ShortcutExtensions.DOLocalRotateQuaternion).Method,
						new InternalGlobals.__GEN_DELEGATE147(ShortcutExtensions.DOScale).Method,
						new InternalGlobals.__GEN_DELEGATE148(ShortcutExtensions.DOScale).Method,
						new InternalGlobals.__GEN_DELEGATE149(ShortcutExtensions.DOScaleX).Method,
						new InternalGlobals.__GEN_DELEGATE150(ShortcutExtensions.DOScaleY).Method,
						new InternalGlobals.__GEN_DELEGATE151(ShortcutExtensions.DOScaleZ).Method,
						new InternalGlobals.__GEN_DELEGATE152(ShortcutExtensions.DOLookAt).Method,
						new InternalGlobals.__GEN_DELEGATE153(ShortcutExtensions.DOPunchPosition).Method,
						new InternalGlobals.__GEN_DELEGATE154(ShortcutExtensions.DOPunchScale).Method,
						new InternalGlobals.__GEN_DELEGATE155(ShortcutExtensions.DOPunchRotation).Method,
						new InternalGlobals.__GEN_DELEGATE156(ShortcutExtensions.DOShakePosition).Method,
						new InternalGlobals.__GEN_DELEGATE157(ShortcutExtensions.DOShakePosition).Method,
						new InternalGlobals.__GEN_DELEGATE158(ShortcutExtensions.DOShakeRotation).Method,
						new InternalGlobals.__GEN_DELEGATE159(ShortcutExtensions.DOShakeRotation).Method,
						new InternalGlobals.__GEN_DELEGATE160(ShortcutExtensions.DOShakeScale).Method,
						new InternalGlobals.__GEN_DELEGATE161(ShortcutExtensions.DOShakeScale).Method,
						new InternalGlobals.__GEN_DELEGATE162(ShortcutExtensions.DOJump).Method,
						new InternalGlobals.__GEN_DELEGATE163(ShortcutExtensions.DOLocalJump).Method,
						new InternalGlobals.__GEN_DELEGATE164(ShortcutExtensions.DOPath).Method,
						new InternalGlobals.__GEN_DELEGATE165(ShortcutExtensions.DOLocalPath).Method,
						new InternalGlobals.__GEN_DELEGATE166(ShortcutExtensions.DOPath).Method,
						new InternalGlobals.__GEN_DELEGATE167(ShortcutExtensions.DOLocalPath).Method,
						new InternalGlobals.__GEN_DELEGATE173(ShortcutExtensions.DOBlendableMoveBy).Method,
						new InternalGlobals.__GEN_DELEGATE174(ShortcutExtensions.DOBlendableLocalMoveBy).Method,
						new InternalGlobals.__GEN_DELEGATE175(ShortcutExtensions.DOBlendableRotateBy).Method,
						new InternalGlobals.__GEN_DELEGATE176(ShortcutExtensions.DOBlendableLocalRotateBy).Method,
						new InternalGlobals.__GEN_DELEGATE177(ShortcutExtensions.DOBlendablePunchRotation).Method,
						new InternalGlobals.__GEN_DELEGATE178(ShortcutExtensions.DOBlendableScaleBy).Method
					}
				},
				{
					typeof(Component),
					new List<MethodInfo>
					{
						new InternalGlobals.__GEN_DELEGATE179(ShortcutExtensions.DOComplete).Method,
						new InternalGlobals.__GEN_DELEGATE181(ShortcutExtensions.DOKill).Method,
						new InternalGlobals.__GEN_DELEGATE183(ShortcutExtensions.DOFlip).Method,
						new InternalGlobals.__GEN_DELEGATE185(ShortcutExtensions.DOGoto).Method,
						new InternalGlobals.__GEN_DELEGATE187(ShortcutExtensions.DOPause).Method,
						new InternalGlobals.__GEN_DELEGATE189(ShortcutExtensions.DOPlay).Method,
						new InternalGlobals.__GEN_DELEGATE191(ShortcutExtensions.DOPlayBackwards).Method,
						new InternalGlobals.__GEN_DELEGATE193(ShortcutExtensions.DOPlayForward).Method,
						new InternalGlobals.__GEN_DELEGATE195(ShortcutExtensions.DORestart).Method,
						new InternalGlobals.__GEN_DELEGATE197(ShortcutExtensions.DORewind).Method,
						new InternalGlobals.__GEN_DELEGATE199(ShortcutExtensions.DOSmoothRewind).Method,
						new InternalGlobals.__GEN_DELEGATE201(ShortcutExtensions.DOTogglePause).Method
					}
				}
			};
			InternalGlobals.genTryArrayGetPtr = new InternalGlobals.TryArrayGet(StaticLuaCallbacks.__tryArrayGet);
			InternalGlobals.genTryArraySetPtr = new InternalGlobals.TryArraySet(StaticLuaCallbacks.__tryArraySet);
		}

		internal static volatile InternalGlobals.TryArrayGet genTryArrayGetPtr = null;

		internal static volatile InternalGlobals.TryArraySet genTryArraySetPtr = null;

		internal static volatile ObjectTranslatorPool objectTranslatorPool = new ObjectTranslatorPool();

		internal static volatile int LUA_REGISTRYINDEX = -10000;

		internal static volatile Dictionary<string, string> supportOp = new Dictionary<string, string>
		{
			{
				"op_Addition",
				"__add"
			},
			{
				"op_Subtraction",
				"__sub"
			},
			{
				"op_Multiply",
				"__mul"
			},
			{
				"op_Division",
				"__div"
			},
			{
				"op_Equality",
				"__eq"
			},
			{
				"op_UnaryNegation",
				"__unm"
			},
			{
				"op_LessThan",
				"__lt"
			},
			{
				"op_LessThanOrEqual",
				"__le"
			},
			{
				"op_Modulus",
				"__mod"
			},
			{
				"op_BitwiseAnd",
				"__band"
			},
			{
				"op_BitwiseOr",
				"__bor"
			},
			{
				"op_ExclusiveOr",
				"__bxor"
			},
			{
				"op_OnesComplement",
				"__bnot"
			},
			{
				"op_LeftShift",
				"__shl"
			},
			{
				"op_RightShift",
				"__shr"
			}
		};

		internal static volatile Dictionary<Type, IEnumerable<MethodInfo>> extensionMethodMap = null;

		internal static volatile lua_CSFunction LazyReflectionWrap = new lua_CSFunction(Utils.LazyReflectionCall);

		private delegate void __GEN_DELEGATE0(Tween t);

		private delegate void __GEN_DELEGATE1(Tween t, bool withCallbacks);

		private delegate void __GEN_DELEGATE2(Tween t);

		private delegate void __GEN_DELEGATE3(Tween t);

		private delegate void __GEN_DELEGATE4(Tween t, float to, bool andPlay);

		private delegate void __GEN_DELEGATE5(Tween t, bool complete);

		private delegate Tween __GEN_DELEGATE6(Tween t);

		private delegate Tween __GEN_DELEGATE7(Tween t);

		private delegate void __GEN_DELEGATE8(Tween t);

		private delegate void __GEN_DELEGATE9(Tween t);

		private delegate void __GEN_DELEGATE10(Tween t, bool includeDelay, float changeDelayTo);

		private delegate void __GEN_DELEGATE11(Tween t, bool includeDelay);

		private delegate void __GEN_DELEGATE12(Tween t);

		private delegate void __GEN_DELEGATE13(Tween t);

		private delegate void __GEN_DELEGATE14(Tween t, int waypointIndex, bool andPlay);

		private delegate YieldInstruction __GEN_DELEGATE15(Tween t);

		private delegate YieldInstruction __GEN_DELEGATE16(Tween t);

		private delegate YieldInstruction __GEN_DELEGATE17(Tween t);

		private delegate YieldInstruction __GEN_DELEGATE18(Tween t, int elapsedLoops);

		private delegate YieldInstruction __GEN_DELEGATE19(Tween t, float position);

		private delegate Coroutine __GEN_DELEGATE20(Tween t);

		private delegate int __GEN_DELEGATE21(Tween t);

		private delegate float __GEN_DELEGATE22(Tween t);

		private delegate float __GEN_DELEGATE23(Tween t, bool includeLoops);

		private delegate float __GEN_DELEGATE24(Tween t, bool includeLoops);

		private delegate float __GEN_DELEGATE25(Tween t, bool includeLoops);

		private delegate float __GEN_DELEGATE26(Tween t);

		private delegate bool __GEN_DELEGATE27(Tween t);

		private delegate bool __GEN_DELEGATE28(Tween t);

		private delegate bool __GEN_DELEGATE29(Tween t);

		private delegate bool __GEN_DELEGATE30(Tween t);

		private delegate bool __GEN_DELEGATE31(Tween t);

		private delegate int __GEN_DELEGATE32(Tween t);

		private delegate Vector3 __GEN_DELEGATE33(Tween t, float pathPercentage);

		private delegate Vector3[] __GEN_DELEGATE34(Tween t, int subdivisionsXSegment);

		private delegate float __GEN_DELEGATE35(Tween t);

		private delegate Tween __GEN_DELEGATE36(Tween t);

		private delegate Tween __GEN_DELEGATE37(Tween t, bool autoKillOnCompletion);

		private delegate Tween __GEN_DELEGATE38(Tween t, object objectId);

		private delegate Tween __GEN_DELEGATE39(Tween t, string stringId);

		private delegate Tween __GEN_DELEGATE40(Tween t, int intId);

		private delegate Tween __GEN_DELEGATE41(Tween t, GameObject gameObject);

		private delegate Tween __GEN_DELEGATE42(Tween t, GameObject gameObject, LinkBehaviour behaviour);

		private delegate Tween __GEN_DELEGATE43(Tween t, object target);

		private delegate Tween __GEN_DELEGATE44(Tween t, int loops);

		private delegate Tween __GEN_DELEGATE45(Tween t, int loops, LoopType loopType);

		private delegate Tween __GEN_DELEGATE46(Tween t, Ease ease);

		private delegate Tween __GEN_DELEGATE47(Tween t, Ease ease, float overshoot);

		private delegate Tween __GEN_DELEGATE48(Tween t, Ease ease, float amplitude, float period);

		private delegate Tween __GEN_DELEGATE49(Tween t, AnimationCurve animCurve);

		private delegate Tween __GEN_DELEGATE50(Tween t, EaseFunction customEase);

		private delegate Tween __GEN_DELEGATE51(Tween t);

		private delegate Tween __GEN_DELEGATE52(Tween t, bool recyclable);

		private delegate Tween __GEN_DELEGATE53(Tween t, bool isIndependentUpdate);

		private delegate Tween __GEN_DELEGATE54(Tween t, UpdateType updateType);

		private delegate Tween __GEN_DELEGATE55(Tween t, UpdateType updateType, bool isIndependentUpdate);

		private delegate Tween __GEN_DELEGATE56(Tween t, TweenCallback action);

		private delegate Tween __GEN_DELEGATE57(Tween t, TweenCallback action);

		private delegate Tween __GEN_DELEGATE58(Tween t, TweenCallback action);

		private delegate Tween __GEN_DELEGATE59(Tween t, TweenCallback action);

		private delegate Tween __GEN_DELEGATE60(Tween t, TweenCallback action);

		private delegate Tween __GEN_DELEGATE61(Tween t, TweenCallback action);

		private delegate Tween __GEN_DELEGATE62(Tween t, TweenCallback action);

		private delegate Tween __GEN_DELEGATE63(Tween t, TweenCallback action);

		private delegate Tween __GEN_DELEGATE64(Tween t, TweenCallback<int> action);

		private delegate Tween __GEN_DELEGATE65(Tween t, Tween asTween);

		private delegate Tween __GEN_DELEGATE66(Tween t, TweenParams tweenParams);

		private delegate Sequence __GEN_DELEGATE67(Sequence s, Tween t);

		private delegate Sequence __GEN_DELEGATE68(Sequence s, Tween t);

		private delegate Sequence __GEN_DELEGATE69(Sequence s, Tween t);

		private delegate Sequence __GEN_DELEGATE70(Sequence s, float atPosition, Tween t);

		private delegate Sequence __GEN_DELEGATE71(Sequence s, float interval);

		private delegate Sequence __GEN_DELEGATE72(Sequence s, float interval);

		private delegate Sequence __GEN_DELEGATE73(Sequence s, TweenCallback callback);

		private delegate Sequence __GEN_DELEGATE74(Sequence s, TweenCallback callback);

		private delegate Sequence __GEN_DELEGATE75(Sequence s, float atPosition, TweenCallback callback);

		private delegate Tweener __GEN_DELEGATE76(Tweener t);

		private delegate Tweener __GEN_DELEGATE77(Tweener t, bool isRelative);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE78(TweenerCore<Color, Color, ColorOptions> t, float fromAlphaValue, bool setImmediately);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE79(TweenerCore<Vector3, Vector3, VectorOptions> t, float fromValue, bool setImmediately);

		private delegate Tween __GEN_DELEGATE80(Tween t, float delay);

		private delegate Tween __GEN_DELEGATE81(Tween t);

		private delegate Tween __GEN_DELEGATE82(Tween t, bool isRelative);

		private delegate Tween __GEN_DELEGATE83(Tween t);

		private delegate Tween __GEN_DELEGATE84(Tween t, bool isSpeedBased);

		private delegate Tweener __GEN_DELEGATE85(TweenerCore<float, float, FloatOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE86(TweenerCore<Vector2, Vector2, VectorOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE87(TweenerCore<Vector2, Vector2, VectorOptions> t, AxisConstraint axisConstraint, bool snapping);

		private delegate Tweener __GEN_DELEGATE88(TweenerCore<Vector3, Vector3, VectorOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE89(TweenerCore<Vector3, Vector3, VectorOptions> t, AxisConstraint axisConstraint, bool snapping);

		private delegate Tweener __GEN_DELEGATE90(TweenerCore<Vector4, Vector4, VectorOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE91(TweenerCore<Vector4, Vector4, VectorOptions> t, AxisConstraint axisConstraint, bool snapping);

		private delegate Tweener __GEN_DELEGATE92(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, bool useShortest360Route);

		private delegate Tweener __GEN_DELEGATE93(TweenerCore<Color, Color, ColorOptions> t, bool alphaOnly);

		private delegate Tweener __GEN_DELEGATE94(TweenerCore<Rect, Rect, RectOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE95(TweenerCore<string, string, StringOptions> t, bool richTextEnabled, ScrambleMode scrambleMode, string scrambleChars);

		private delegate Tweener __GEN_DELEGATE96(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE97(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, AxisConstraint axisConstraint, bool snapping);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE98(TweenerCore<Vector3, Path, PathOptions> t, AxisConstraint lockPosition, AxisConstraint lockRotation);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE99(TweenerCore<Vector3, Path, PathOptions> t, bool closePath, AxisConstraint lockPosition, AxisConstraint lockRotation);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE100(TweenerCore<Vector3, Path, PathOptions> t, Vector3 lookAtPosition, Vector3? forwardDirection, Vector3? up);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE101(TweenerCore<Vector3, Path, PathOptions> t, Transform lookAtTransform, Vector3? forwardDirection, Vector3? up);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE102(TweenerCore<Vector3, Path, PathOptions> t, float lookAhead, Vector3? forwardDirection, Vector3? up);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE103(Camera target, float endValue, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE104(Camera target, Color endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE105(Camera target, float endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE106(Camera target, float endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE107(Camera target, float endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE108(Camera target, float endValue, float duration);

		private delegate TweenerCore<Rect, Rect, RectOptions> __GEN_DELEGATE109(Camera target, Rect endValue, float duration);

		private delegate TweenerCore<Rect, Rect, RectOptions> __GEN_DELEGATE110(Camera target, Rect endValue, float duration);

		private delegate Tweener __GEN_DELEGATE111(Camera target, float duration, float strength, int vibrato, float randomness, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE112(Camera target, float duration, Vector3 strength, int vibrato, float randomness, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE113(Camera target, float duration, float strength, int vibrato, float randomness, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE114(Camera target, float duration, Vector3 strength, int vibrato, float randomness, bool fadeOut);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE115(Light target, Color endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE116(Light target, float endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE117(Light target, float endValue, float duration);

		private delegate Tweener __GEN_DELEGATE118(LineRenderer target, Color2 startValue, Color2 endValue, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE119(Material target, Color endValue, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE120(Material target, Color endValue, string property, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE121(Material target, Color endValue, int propertyID, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE122(Material target, float endValue, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE123(Material target, float endValue, string property, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE124(Material target, float endValue, int propertyID, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE125(Material target, float endValue, string property, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE126(Material target, float endValue, int propertyID, float duration);

		private delegate TweenerCore<Vector2, Vector2, VectorOptions> __GEN_DELEGATE127(Material target, Vector2 endValue, float duration);

		private delegate TweenerCore<Vector2, Vector2, VectorOptions> __GEN_DELEGATE128(Material target, Vector2 endValue, string property, float duration);

		private delegate TweenerCore<Vector2, Vector2, VectorOptions> __GEN_DELEGATE129(Material target, Vector2 endValue, float duration);

		private delegate TweenerCore<Vector2, Vector2, VectorOptions> __GEN_DELEGATE130(Material target, Vector2 endValue, string property, float duration);

		private delegate TweenerCore<Vector4, Vector4, VectorOptions> __GEN_DELEGATE131(Material target, Vector4 endValue, string property, float duration);

		private delegate TweenerCore<Vector4, Vector4, VectorOptions> __GEN_DELEGATE132(Material target, Vector4 endValue, int propertyID, float duration);

		private delegate Tweener __GEN_DELEGATE133(TrailRenderer target, float toStartWidth, float toEndWidth, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE134(TrailRenderer target, float endValue, float duration);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE135(Transform target, Vector3 endValue, float duration, bool snapping);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE136(Transform target, float endValue, float duration, bool snapping);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE137(Transform target, float endValue, float duration, bool snapping);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE138(Transform target, float endValue, float duration, bool snapping);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE139(Transform target, Vector3 endValue, float duration, bool snapping);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE140(Transform target, float endValue, float duration, bool snapping);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE141(Transform target, float endValue, float duration, bool snapping);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE142(Transform target, float endValue, float duration, bool snapping);

		private delegate TweenerCore<Quaternion, Vector3, QuaternionOptions> __GEN_DELEGATE143(Transform target, Vector3 endValue, float duration, RotateMode mode);

		private delegate TweenerCore<Quaternion, Quaternion, NoOptions> __GEN_DELEGATE144(Transform target, Quaternion endValue, float duration);

		private delegate TweenerCore<Quaternion, Vector3, QuaternionOptions> __GEN_DELEGATE145(Transform target, Vector3 endValue, float duration, RotateMode mode);

		private delegate TweenerCore<Quaternion, Quaternion, NoOptions> __GEN_DELEGATE146(Transform target, Quaternion endValue, float duration);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE147(Transform target, Vector3 endValue, float duration);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE148(Transform target, float endValue, float duration);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE149(Transform target, float endValue, float duration);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE150(Transform target, float endValue, float duration);

		private delegate TweenerCore<Vector3, Vector3, VectorOptions> __GEN_DELEGATE151(Transform target, float endValue, float duration);

		private delegate Tweener __GEN_DELEGATE152(Transform target, Vector3 towards, float duration, AxisConstraint axisConstraint, Vector3? up);

		private delegate Tweener __GEN_DELEGATE153(Transform target, Vector3 punch, float duration, int vibrato, float elasticity, bool snapping);

		private delegate Tweener __GEN_DELEGATE154(Transform target, Vector3 punch, float duration, int vibrato, float elasticity);

		private delegate Tweener __GEN_DELEGATE155(Transform target, Vector3 punch, float duration, int vibrato, float elasticity);

		private delegate Tweener __GEN_DELEGATE156(Transform target, float duration, float strength, int vibrato, float randomness, bool snapping, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE157(Transform target, float duration, Vector3 strength, int vibrato, float randomness, bool snapping, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE158(Transform target, float duration, float strength, int vibrato, float randomness, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE159(Transform target, float duration, Vector3 strength, int vibrato, float randomness, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE160(Transform target, float duration, float strength, int vibrato, float randomness, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE161(Transform target, float duration, Vector3 strength, int vibrato, float randomness, bool fadeOut);

		private delegate Sequence __GEN_DELEGATE162(Transform target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping);

		private delegate Sequence __GEN_DELEGATE163(Transform target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE164(Transform target, Vector3[] path, float duration, PathType pathType, PathMode pathMode, int resolution, Color? gizmoColor);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE165(Transform target, Vector3[] path, float duration, PathType pathType, PathMode pathMode, int resolution, Color? gizmoColor);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE166(Transform target, Path path, float duration, PathMode pathMode);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE167(Transform target, Path path, float duration, PathMode pathMode);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE168(Tween target, float endValue, float duration);

		private delegate Tweener __GEN_DELEGATE169(Light target, Color endValue, float duration);

		private delegate Tweener __GEN_DELEGATE170(Material target, Color endValue, float duration);

		private delegate Tweener __GEN_DELEGATE171(Material target, Color endValue, string property, float duration);

		private delegate Tweener __GEN_DELEGATE172(Material target, Color endValue, int propertyID, float duration);

		private delegate Tweener __GEN_DELEGATE173(Transform target, Vector3 byValue, float duration, bool snapping);

		private delegate Tweener __GEN_DELEGATE174(Transform target, Vector3 byValue, float duration, bool snapping);

		private delegate Tweener __GEN_DELEGATE175(Transform target, Vector3 byValue, float duration, RotateMode mode);

		private delegate Tweener __GEN_DELEGATE176(Transform target, Vector3 byValue, float duration, RotateMode mode);

		private delegate Tweener __GEN_DELEGATE177(Transform target, Vector3 punch, float duration, int vibrato, float elasticity);

		private delegate Tweener __GEN_DELEGATE178(Transform target, Vector3 byValue, float duration);

		private delegate int __GEN_DELEGATE179(Component target, bool withCallbacks);

		private delegate int __GEN_DELEGATE180(Material target, bool withCallbacks);

		private delegate int __GEN_DELEGATE181(Component target, bool complete);

		private delegate int __GEN_DELEGATE182(Material target, bool complete);

		private delegate int __GEN_DELEGATE183(Component target);

		private delegate int __GEN_DELEGATE184(Material target);

		private delegate int __GEN_DELEGATE185(Component target, float to, bool andPlay);

		private delegate int __GEN_DELEGATE186(Material target, float to, bool andPlay);

		private delegate int __GEN_DELEGATE187(Component target);

		private delegate int __GEN_DELEGATE188(Material target);

		private delegate int __GEN_DELEGATE189(Component target);

		private delegate int __GEN_DELEGATE190(Material target);

		private delegate int __GEN_DELEGATE191(Component target);

		private delegate int __GEN_DELEGATE192(Material target);

		private delegate int __GEN_DELEGATE193(Component target);

		private delegate int __GEN_DELEGATE194(Material target);

		private delegate int __GEN_DELEGATE195(Component target, bool includeDelay);

		private delegate int __GEN_DELEGATE196(Material target, bool includeDelay);

		private delegate int __GEN_DELEGATE197(Component target, bool includeDelay);

		private delegate int __GEN_DELEGATE198(Material target, bool includeDelay);

		private delegate int __GEN_DELEGATE199(Component target);

		private delegate int __GEN_DELEGATE200(Material target);

		private delegate int __GEN_DELEGATE201(Component target);

		private delegate int __GEN_DELEGATE202(Material target);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE203(TweenerCore<Color, Color, ColorOptions> t, float fromAlphaValue, bool setImmediately);

		private delegate Tweener __GEN_DELEGATE204(TweenerCore<float, float, FloatOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE205(TweenerCore<Vector2, Vector2, VectorOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE206(TweenerCore<Vector2, Vector2, VectorOptions> t, AxisConstraint axisConstraint, bool snapping);

		private delegate Tweener __GEN_DELEGATE207(TweenerCore<Vector4, Vector4, VectorOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE208(TweenerCore<Vector4, Vector4, VectorOptions> t, AxisConstraint axisConstraint, bool snapping);

		private delegate Tweener __GEN_DELEGATE209(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, bool useShortest360Route);

		private delegate Tweener __GEN_DELEGATE210(TweenerCore<Color, Color, ColorOptions> t, bool alphaOnly);

		private delegate Tweener __GEN_DELEGATE211(TweenerCore<Rect, Rect, RectOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE212(TweenerCore<string, string, StringOptions> t, bool richTextEnabled, ScrambleMode scrambleMode, string scrambleChars);

		private delegate Tweener __GEN_DELEGATE213(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, bool snapping);

		private delegate Tweener __GEN_DELEGATE214(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, AxisConstraint axisConstraint, bool snapping);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE215(TweenerCore<Vector3, Path, PathOptions> t, AxisConstraint lockPosition, AxisConstraint lockRotation);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE216(TweenerCore<Vector3, Path, PathOptions> t, bool closePath, AxisConstraint lockPosition, AxisConstraint lockRotation);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE217(TweenerCore<Vector3, Path, PathOptions> t, Vector3 lookAtPosition, Vector3? forwardDirection, Vector3? up);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE218(TweenerCore<Vector3, Path, PathOptions> t, Transform lookAtTransform, Vector3? forwardDirection, Vector3? up);

		private delegate TweenerCore<Vector3, Path, PathOptions> __GEN_DELEGATE219(TweenerCore<Vector3, Path, PathOptions> t, float lookAhead, Vector3? forwardDirection, Vector3? up);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE220(Camera target, float endValue, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE221(Camera target, Color endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE222(Camera target, float endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE223(Camera target, float endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE224(Camera target, float endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE225(Camera target, float endValue, float duration);

		private delegate TweenerCore<Rect, Rect, RectOptions> __GEN_DELEGATE226(Camera target, Rect endValue, float duration);

		private delegate TweenerCore<Rect, Rect, RectOptions> __GEN_DELEGATE227(Camera target, Rect endValue, float duration);

		private delegate Tweener __GEN_DELEGATE228(Camera target, float duration, float strength, int vibrato, float randomness, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE229(Camera target, float duration, Vector3 strength, int vibrato, float randomness, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE230(Camera target, float duration, float strength, int vibrato, float randomness, bool fadeOut);

		private delegate Tweener __GEN_DELEGATE231(Camera target, float duration, Vector3 strength, int vibrato, float randomness, bool fadeOut);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE232(Light target, Color endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE233(Light target, float endValue, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE234(Light target, float endValue, float duration);

		private delegate Tweener __GEN_DELEGATE235(LineRenderer target, Color2 startValue, Color2 endValue, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE236(Material target, Color endValue, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE237(Material target, Color endValue, string property, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE238(Material target, Color endValue, int propertyID, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE239(Material target, float endValue, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE240(Material target, float endValue, string property, float duration);

		private delegate TweenerCore<Color, Color, ColorOptions> __GEN_DELEGATE241(Material target, float endValue, int propertyID, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE242(Material target, float endValue, string property, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE243(Material target, float endValue, int propertyID, float duration);

		private delegate TweenerCore<Vector2, Vector2, VectorOptions> __GEN_DELEGATE244(Material target, Vector2 endValue, float duration);

		private delegate TweenerCore<Vector2, Vector2, VectorOptions> __GEN_DELEGATE245(Material target, Vector2 endValue, string property, float duration);

		private delegate TweenerCore<Vector2, Vector2, VectorOptions> __GEN_DELEGATE246(Material target, Vector2 endValue, float duration);

		private delegate TweenerCore<Vector2, Vector2, VectorOptions> __GEN_DELEGATE247(Material target, Vector2 endValue, string property, float duration);

		private delegate TweenerCore<Vector4, Vector4, VectorOptions> __GEN_DELEGATE248(Material target, Vector4 endValue, string property, float duration);

		private delegate TweenerCore<Vector4, Vector4, VectorOptions> __GEN_DELEGATE249(Material target, Vector4 endValue, int propertyID, float duration);

		private delegate Tweener __GEN_DELEGATE250(TrailRenderer target, float toStartWidth, float toEndWidth, float duration);

		private delegate TweenerCore<float, float, FloatOptions> __GEN_DELEGATE251(TrailRenderer target, float endValue, float duration);

		private delegate Tweener __GEN_DELEGATE252(Light target, Color endValue, float duration);

		private delegate Tweener __GEN_DELEGATE253(Material target, Color endValue, float duration);

		private delegate Tweener __GEN_DELEGATE254(Material target, Color endValue, string property, float duration);

		private delegate Tweener __GEN_DELEGATE255(Material target, Color endValue, int propertyID, float duration);

		private delegate int __GEN_DELEGATE256(Material target, bool withCallbacks);

		private delegate int __GEN_DELEGATE257(Material target, bool complete);

		private delegate int __GEN_DELEGATE258(Material target);

		private delegate int __GEN_DELEGATE259(Material target, float to, bool andPlay);

		private delegate int __GEN_DELEGATE260(Material target);

		private delegate int __GEN_DELEGATE261(Material target);

		private delegate int __GEN_DELEGATE262(Material target);

		private delegate int __GEN_DELEGATE263(Material target);

		private delegate int __GEN_DELEGATE264(Material target, bool includeDelay);

		private delegate int __GEN_DELEGATE265(Material target, bool includeDelay);

		private delegate int __GEN_DELEGATE266(Material target);

		private delegate int __GEN_DELEGATE267(Material target);

		internal delegate bool TryArrayGet(Type type, IntPtr L, ObjectTranslator translator, object obj, int index);

		internal delegate bool TryArraySet(Type type, IntPtr L, ObjectTranslator translator, object obj, int array_idx, int obj_idx);
	}
}
