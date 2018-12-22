using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManiaSkinConfigGenerator
{
    class Skin
    {
        static string skinname = "", keyImage="", keyImageD="", noteImage="", noteImageH="", noteImageT="", noteImageL="", stageleft="", stageright="";

        public static void SetSkinName(string name)
        {
            skinname = name;
        }

        public static void SetKeyImage(string name)
        {
            keyImage = name;
        }

        public static void SetKeyImageD(string name)
        {
            keyImageD = name;
        }

        public static void SetNoteImage(string name)
        {
            noteImage = name;
        }

        public static void SetNoteImageH(string name)
        {
            noteImageH = name;
        }

        public static void SetNoteImageT(string name)
        {
            noteImageT = name;
        }

        public static void SetNoteImagL(string name)
        {
            noteImageL = name;
        }

        public static void SetStageLeft(string name)
        {
            stageleft = name;
        }

        public static void SetStageRight(string name)
        {
            stageright = name;
        }

        public static string GetSkinName()
        {
            return skinname;
        }

        public static string GetKeyImage()
        {
            return keyImage;
        }

        public static string GetKeyImageD()
        {
            return keyImageD;
        }

        public static string GetNoteImage()
        {
            return noteImage;
        }

        public static string GetNoteImageH()
        {
            return noteImageH;
        }

        public static string GetNoteImageT()
        {
            return noteImageT;
        }

        public static string GetNoteImageL()
        {
            return noteImageL;
        }

        public static string GetStageLeft()
        {
            return stageleft;
        }

        public static string GetStageRight()
        {
            return stageright;
        }
    }
}
