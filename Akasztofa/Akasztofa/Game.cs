using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

public class Game
{
    private readonly List<string> _szavakKonnyu;
    private readonly List<string> _szavakNehez;
    private string _aktualisSzo;
    private string _jatekKimenete;
    private Stopwatch _stopwatch;

    public string Nev { get; set; }
    public string Nehezseg { get; set; }
    public TimeSpan MegoldasiIdo => _stopwatch.Elapsed;

    public Game(IConfiguration configuration)
    {
        _szavakKonnyu = configuration.GetSection("Szavak:Konnyu").Get<List<string>>();
        _szavakNehez = configuration.GetSection("Szavak:Nehez").Get<List<string>>();
    }

    public void Kezdes(string nehezseg)
    {
        _stopwatch = Stopwatch.StartNew();
        Nehezseg = nehezseg;
        _aktualisSzo = nehezseg == "Konnyu"
            ? _szavakKonnyu[new Random().Next(_szavakKonnyu.Count)]
            : _szavakNehez[new Random().Next(_szavakNehez.Count)];
        _jatekKimenete = new string('_', _aktualisSzo.Length);
    }

    public bool Tippel(string betu)
    {
        bool tippIgaz = false;
        char[] kimenet = _jatekKimenete.ToCharArray();

        for (int i = 0; i < _aktualisSzo.Length; i++)
        {
            if (_aktualisSzo[i] == betu[0] && kimenet[i] == '_')
            {
                kimenet[i] = betu[0];
                tippIgaz = true;
            }
        }

        _jatekKimenete = new string(kimenet);

        return tippIgaz;
    }

    public bool JatekVege()
    {
        return !_jatekKimenete.Contains('_');
    }
}
