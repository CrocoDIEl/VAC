﻿using System;
using Math_Module;
using External_Controller;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Interpretation_Controller
{
    static public class Interpretator
    {
        public static void Interpretate()
        {
            string input = External_Controller.Controller.input;
            string output = External_Controller.Controller.output;
            FileStream inp = null, outp = null;
            try
            {
                inp = new FileStream(input, FileMode.Open);
                outp = new FileStream(output, FileMode.OpenOrCreate);
            }
            catch
            {
                MessageBox.Show("Некоректный путь входного/выходного файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            StreamReader reader = new StreamReader(inp);
            StreamWriter writer = new StreamWriter(outp);
            List<Math_Field> Data = new List<Math_Field>();
            string s;
            try
            {
                for(int i = 0; i < Controller.dates.Count; i++)
                {
                    s = reader.ReadLine();
                    switch(Controller.dates[i].information.name)
                    {
                        case "N":
                            {
                                List<string> dat = new List<string>();
                                for (int j = s.Length-1; j >= 0; j -= (int)N.uint_size_div)
                                {
                                    dat.Insert(0, s.Substring(i, (int)N.uint_size_div));
                                }
                                Data.Add(new N(dat));
                            }
                            break;
                        case "Z":
                            {
                                List<string> dat = new List<string>();
                                for (int j = s.Length-1; j >= 0; j -= (int)N.uint_size_div)
                                {
                                    dat.Insert(0, s.Substring(i, (int)N.uint_size_div));
                                }
                                Data.Add(new Z(dat));
                            }
                            break;
                        case "Q":
                            {
                                string first = s.Split('/')[0];
                                string second;
                                try
                                {
                                    second = s.Split('/')[1];
                                }
                                catch
                                {
                                    second = "1";
                                }
                                List<string> dato = new List<string>();
                                for (int j = first.Length-1; j >= 0; j -= (int)N.uint_size_div)
                                {
                                    dato.Insert(0, first.Substring(i, (int)N.uint_size_div));
                                }
                                List<string> datt = new List<string>();
                                for (int j = second.Length -1; j >= 0; j -= (int)N.uint_size_div)
                                {
                                    datt.Insert(0, second.Substring(i, (int)N.uint_size_div));
                                }
                                Data.Add(new Q(dato, datt));
                            }
                            break;
                        case "P":
                            {
                                s = s.Replace(" ", "");
                                s = s.Replace('+', ' ');
                                s = s.Replace("-", " -");
                                s = s.Replace("x^", " ");
                                string[] polinom = s.Split(' ');
                                List<List<string>[]> Mnogochlen = new List<List<string>[]>();
                                for(int j = 0; j < polinom.Length; j += 2)
                                {
                                    Mnogochlen.Add(new List<string>[2]);
                                    string first = polinom[j].Split('/')[0];
                                    string second;
                                    try
                                    {
                                        second = s.Split('/')[1];
                                    }
                                    catch
                                    {
                                        second = "1";
                                    }
                                    List<string> dato = new List<string>();
                                    for (int k = polinom[j].Length; k >= 0; k -= (int)N.uint_size_div)
                                    {
                                        dato.Insert(0, polinom[j].Substring(i, (int)N.uint_size_div));
                                    }
                                    List<string> datt = new List<string>();
                                    if (j + 1 < polinom.Length)
                                    {
                                        for (int k = polinom[j+1].Length; k >= 0; k -= (int)N.uint_size_div)
                                        {
                                            datt.Insert(0, polinom[j+1].Substring(i, (int)N.uint_size_div));
                                        }
                                    }
                                    else
                                    {
                                        datt.Add("0");
                                    }
                                    Mnogochlen[j][0] = dato;
                                    Mnogochlen[j][1] = datt;

                                }
                            }
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Некоректное содержание входного файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
