using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems
{
    [MenuItem("Geekbrains/����� ���� �1 ")]
    private static void MenuOption()
    {
        EditorWindow.GetWindow(typeof(MyWindow), false, "Geekbrains");
    }

    [MenuItem("Geekbrains/����� ���� �2 %#a")]
    private static void NewMenuOption()
    {
    }

}
