using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems
{
    [MenuItem("Geekbrains/Пункт меню №1 ")]
    private static void MenuOption()
    {
        EditorWindow.GetWindow(typeof(MyWindow), false, "Geekbrains");
    }

    [MenuItem("Geekbrains/Пункт меню №2 %#a")]
    private static void NewMenuOption()
    {
    }

}
