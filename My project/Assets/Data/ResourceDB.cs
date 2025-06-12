using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ResourceDB : ScriptableObject
{
	public List<CharacterEntity> Character; // Replace 'EntityType' to an actual type that is serializable.
	public List<CharImageEntity> Image;
}
