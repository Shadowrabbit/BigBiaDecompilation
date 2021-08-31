using System;

[Flags, Serializable]
public enum CharacterTag : ulong
{
	受虐狂 = 1UL,
	弱智 = 2UL,
	猥琐 = 4UL,
	善良 = 8UL,
	大度 = 16UL,
	忠诚 = 32UL,
	聪明 = 64UL
}
