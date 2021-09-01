using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class ChuShouCardLogic : CardLogic
{
	public override IEnumerator CustomAttack(CardSlotData target)
	{
		Quaternion rotation = this.CardData.CardGameObject.transform.rotation;
		Vector3 normalized = (target.ChildCardData.CardGameObject.transform.position - this.CardData.CardGameObject.transform.position).normalized;
		Quaternion endValue = Quaternion.AngleAxis(ChuShouCardLogic.DotToAngle(Vector3.back, normalized), Vector3.up);
		this.CardData.CardGameObject.transform.DORotateQuaternion(endValue, 1f).OnComplete(delegate
		{
			this.CardData.CardGameObject.transform.DORotate(new Vector3(0f, 0f, 0f), 1f, RotateMode.Fast);
		});
		this.CardData.CardGameObject.transform.GetComponentInChildren<Animator>().SetTrigger("Attack");
		yield return new WaitForSeconds(0.5f);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		yield break;
	}

	public static float DotToAngle(Vector3 from, Vector3 to)
	{
		float num = Mathf.Acos(Vector3.Dot(from.normalized, to.normalized));
		num = ((to.normalized.x > 0f) ? (-num) : num);
		return num * 57.29578f;
	}
}
