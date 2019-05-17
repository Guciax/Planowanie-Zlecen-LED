using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Planowanie_Zlecen_LED
{
    public class CheckStructuresForLeds
    {
        public static List<string> currentLeds = new List<string>();

        public static void CheckStructureForModel(string modelId, string ledTextBoxString, Label lInfo)
        {
            ledTextBoxString = ledTextBoxString.Replace(" ", "");
            lInfo.ForeColor = Color.Black;
            currentLeds = ledTextBoxString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(nc => new string(nc.Where(c => Char.IsDigit(c)).ToArray()))
                                          .Where(nc => nc.Length == 12)
                                          .Distinct()
                                          .ToList();

            var dtModel = MST.MES.DtTools.GetDtModel00(modelId, DevTools.devToolsDb);
            if (dtModel == null)
            {
                lInfo.Text = "Brak modelu w strukturze DevTools";
                return;
            }

            var ledFromDevTools = MST.MES.DtTools.GetModelLedCollective12NC(dtModel);
            if (ledFromDevTools.Count == 0)
            {
                lInfo.Text = "Brak informacji o diodach LED w strukturze DevTools";
                return;
            }

            lInfo.Text = "Sprawdzenie poprawności struktur:" + Environment.NewLine;
            foreach (var led12NC in currentLeds)
            {
                string nc12Formated = led12NC.Insert(4, " ").Insert(8, " ");
                lInfo.ForeColor = Color.Black;
                if (!DevTools.nc12ToCollective.ContainsKey(led12NC))
                {
                    lInfo.Text += $"{nc12Formated} - Brak diody LED w systemie Oracle. Sprawdź poprawność danych.";
                    lInfo.ForeColor = Color.Red;
                    return;
                }

                if (DevTools.nc12ToCollective[led12NC] == "")
                {
                    lInfo.Text += $"{nc12Formated} - Brak informacji o Collective 12NC dla tej diody " + Environment.NewLine + "               Uruchom narzędzie 'Sparing – DevKit.exe'";
                    lInfo.ForeColor = Color.Red;
                    return;
                }

                string collective = DevTools.nc12ToCollective[led12NC];

                if (ledFromDevTools.Contains(collective))
                {
                    lInfo.Text += nc12Formated + " - OK";
                }
                else
                {
                    lInfo.Text += nc12Formated + " - NIEZGODŚĆ ZE STRUKTURĄ!!!";
                    lInfo.ForeColor = Color.Red;
                }
                lInfo.Text += Environment.NewLine;
            }
        }
    }
}