using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(StringTable))]
[CustomPropertyDrawer(typeof(ObjectTable))]
public class CustomDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }